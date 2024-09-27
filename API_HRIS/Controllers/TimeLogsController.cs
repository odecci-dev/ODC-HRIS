using API_HRIS.Manager;
using API_HRIS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Diagnostics;
using System.Globalization;
using System;
using Microsoft.IdentityModel.Tokens;

namespace API_HRIS.Controllers
{
    [Authorize("ApiKey")]
    [Route("[controller]/[action]")]
    [ApiController]
    public class TimeLogsController : ControllerBase
    {
        private readonly ODC_HRISContext _context;
        DbManager db = new DbManager();
        DBMethods dbmet = new DBMethods();

        public TimeLogsController(ODC_HRISContext context)
        {
            _context = context;
        }

        public class TimeLogsParam
        {
            public string? Usertype { get; set; }
            public string? UserId { get; set; }
        }
       
        [HttpPost]
        public async Task<IActionResult> TimeLogsList(TimeLogsParam data)
        {
            var result = (dynamic)null;
            var validation = dbmet.TimeLogsData().Where(a=>a.UserId == data.UserId).FirstOrDefault();
            if(validation != null)
            {
                //
                if(validation.UsertypeId != "2")
                {
                    result = dbmet.TimeLogsData().Where(a => a.UserId == data.UserId).ToList();
                }
                else
                {
                    result = dbmet.TimeLogsData().ToList();
                }
            }
            else
            {
                return BadRequest("ERROR");
            }
            

            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<TblTimeLog>> TimeIn(TblTimeLog data)
        {

            data.Date = DateTime.Now.Date;
            data.TimeIn = DateTime.Now.ToString("hh:mm:ss tt"); ;
            data.TimeOut = null;
            data.Remarks = data.Remarks;
            data.TaskId = data.TaskId;
            data.Status = 1;
            _context.TblTimeLogs.Add(data);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPost]
        public async Task<ActionResult<TblTimeLog>> TimeOut(User tblTimeLog)
        {

            var lastTimein = _context.TblTimeLogs.AsNoTracking().Where(timeLogs => timeLogs.UserId == tblTimeLog.UserId && timeLogs.TimeIn != null && timeLogs.TimeOut == null).OrderByDescending(timeLogs => timeLogs.UserId).FirstOrDefault();
            if(lastTimein != null)
            {

                if (lastTimein.TimeOut.IsNullOrEmpty())
                {

                    lastTimein.TimeOut = DateTime.Now.ToString("hh:mm:ss tt");
                    TimeSpan times = DateTime.Parse(DateTime.Now.ToString("hh:mm:ss tt")).Subtract(DateTime.Parse(lastTimein.TimeIn));
                    lastTimein.RenderedHours = decimal.Parse(times.Hours.ToString() + "." + times.Minutes.ToString());
                    _context.Entry(lastTimein).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
                return Ok("TimeOut");
            }
            else
            {
                return BadRequest("Error!");
            }
          
        }
        public partial class User
        {
            public int? UserId { get; set; }

            //

        }
        [HttpPost]
        public async Task<ActionResult<TblTimeLog>> getLastTimeIn(User tblTimeLog)
        {
            bool lastTimein = true;
            var validation = _context.TblTimeLogs.Where(a => a.UserId == tblTimeLog.UserId).ToList();
            if(validation.Count() != 0 )
            {
                lastTimein = _context.TblTimeLogs.AsNoTracking().Where(timeLogs => timeLogs.UserId == tblTimeLog.UserId && timeLogs.TimeOut == null).OrderByDescending(timeLogs => timeLogs.UserId).ToList().Count() > 0;

            }
            else
            {
                lastTimein = false;

            }
          
            return Ok(lastTimein);
        }
        [HttpPost]
        public async Task<ActionResult<TblTimeLog>> save(string type, TblTimeLog tblTimeLog)
        {
            if (_context.TblTimeLogs == null)
            {
                return Problem("Entity set 'ODC_HRISContext.TblTimeLogs'  is null.");
            }
            //bool hasDuplicateOnSave = (_context.TblUsersModels?.Any(userModel => userModel.Email == tblUserModel.Email)).GetValueOrDefault();
            bool isExist = (_context.TblUsersModels?.Any(userModel => userModel.Id == tblTimeLog.UserId && !userModel.DeleteFlag)).GetValueOrDefault();

            if (!isExist)
            {
                return Conflict("User Id does not Exist");
            }

            try
            {
                if (type.ToLower() == "timein")
                {
                    //string today = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    tblTimeLog.Date = DateTime.Now.Date;
                    tblTimeLog.TimeIn = DateTime.Now.ToString("hh:mm:ss tt"); ;
                    tblTimeLog.TimeOut = null;
                    tblTimeLog.Status = 1;
                    _context.TblTimeLogs.Add(tblTimeLog);
                     await _context.SaveChangesAsync();
                }
                else if (type.ToLower() == "timeout")
                {
                    var lastTimein = _context.TblTimeLogs.AsNoTracking().Where(timeLogs => timeLogs.UserId == tblTimeLog.UserId).OrderBy(timeLogs => timeLogs.Id).LastOrDefault();
                    if (lastTimein.TimeOut.IsNullOrEmpty())
                    {
                      
                        tblTimeLog.TimeIn = lastTimein.TimeIn.ToString();
                        tblTimeLog.TimeOut = DateTime.Now.ToString("hh:mm:ss tt");
                        tblTimeLog.Status = 1;
                        TimeSpan times = DateTime.Parse(tblTimeLog.TimeOut).Subtract(DateTime.Parse(tblTimeLog.TimeIn));
                        tblTimeLog.RenderedHours = decimal.Parse(times.Hours.ToString() + "." + times.Minutes.ToString());
                        _context.Entry(tblTimeLog).State = EntityState.Modified;
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        tblTimeLog.Date = DateTime.Now.Date;
                        tblTimeLog.TimeOut = DateTime.Now.ToString("hh:mm:ss tt"); 
                        tblTimeLog.TimeIn = null;
                        tblTimeLog.Status = 1;
                        _context.TblTimeLogs.Add(tblTimeLog);
                        await _context.SaveChangesAsync();
                    }
                }
                else
                {
                    return Conflict("Invalid Type");
                }

                return CreatedAtAction("save", new { id = tblTimeLog.Id }, tblTimeLog);


            }
            catch (Exception ex)
            {

                return Problem(ex.GetBaseException().ToString());
            }
        }
    }
}
