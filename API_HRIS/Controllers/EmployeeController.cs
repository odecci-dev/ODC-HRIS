
using API_HRIS.Manager;
using API_HRIS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using Org.BouncyCastle.Utilities;
using System.Data;
using System.Drawing.Printing;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.IdentityModel.Tokens;
using API_HRIS.ApplicationModel;
using System.Text;
using static API_HRIS.Manager.DBMethods;
using System.Xml.Linq;
using System;

namespace API_HRIS.Controllers
{
    [Authorize("ApiKey")]
    [Route("[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ODC_HRISContext _context;
        DbManager db = new DbManager();
        DBMethods dbmet = new DBMethods();
        public class BirthTypesSearchFilter
        {
            public string? BirthTypeCode { get; set; }
            public string? BirthTypeDesc { get; set; }
            public int page { get; set; }
            public int pageSize { get; set; }
        }
    
        public EmployeeController(ODC_HRISContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> EmployeeFilteredById(IdFilter data )
        {
            var result = _context.TblUsersModels.Where(a => a.Id == data.Id).OrderByDescending(a => a.DateCreated).ThenByDescending(a => a.DateUpdated).ToList();
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> StatusTypeList()
        {
            return Ok(_context.TblStatusModels.ToList());
        }

        [HttpPost]
        public async Task<IActionResult> EmployeePaginationList(FilterEmployee data)
        {

            try
            {

                var Member = _context.GetEmployees().ToList().OrderByDescending(a=>a.Id);
                string status = "Employee successfully viewed";
                dbmet.InsertAuditTrail("View All Employee" + " " + status, DateTime.Now.ToString("yyyy-MM-dd"), "Employee Module", "User", "0");
                return Ok(Member);


            }

            catch (Exception ex)
            {
                return BadRequest("ERROR");
            }
        }
      
        public class EmployeeViewModel
        {

            public string? Id { get; set; }
            public string Department { get; set; }
            public string UserType { get; set; }
            public string Lname { get; set; }
            public string Fname { get; set; }
            public string Mname { get; set; }
            public string? Suffix { get; set; }
            public string Email { get; set; }
            public string Cno { get; set; }
            public string Gender { get; set; }
            public string DateStarted { get; set; }
            public string CreatedBy { get; set; }
            public string Address { get; set; }
            public string SalaryType { get; set; }
            public string PayrollType { get; set; }
            public string Status { get; set; }
            public string Position { get; set; }
            public string FilePath { get; set; }
        }
        private TblUsersModel buildEmployee(EmployeeViewModel registrationModel)
        {
            var BuffHerdModel = new TblUsersModel()
            {
                UserType = int.Parse(registrationModel.UserType),
                Fullname = registrationModel.Fname + " " + registrationModel.Mname + " " + registrationModel.Lname + " " + registrationModel.Suffix,
                Active = 1,
                Fname = registrationModel.Fname,
                Lname = registrationModel.Lname,
                Mname = registrationModel.Mname,
                Position = int.Parse(registrationModel.Position),
                Suffix = registrationModel.Suffix,
                Status = int.Parse(registrationModel?.Status),
                Department = int.Parse(registrationModel.Department),
                Email = registrationModel.Email,
                Gender = registrationModel.Gender,
                DateStarted = Convert.ToDateTime(registrationModel.DateStarted),
                DateCreated = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd")),
                CreatedBy = registrationModel.CreatedBy,
                PayrollType = int.Parse(registrationModel.PayrollType),
                SalaryType = int.Parse(registrationModel.SalaryType),
                Address = registrationModel.Address
            };

            return BuffHerdModel;
        }
        [HttpPost]
        public async Task<IActionResult> saveemployee(EmployeeViewModel data)
        {
            string status = "";
            if (_context.TblUsersModels == null)
            {
                return Problem("Entity set 'ODC_HRISContext.TblUsersModels'  is null.");
            }
            bool hasDuplicateOnSave = (_context.TblUsersModels?.Any(userModel =>  userModel.Email == data.Email)).GetValueOrDefault();


            try
            {


                var EmployeeModel = buildEmployee(data);
                if (data.Id == null)
                {

                    if (hasDuplicateOnSave)
                    {
                        return Conflict("Entity already exists");
                    }
                    
                    _context.TblUsersModels.Add(EmployeeModel);
                    await _context.SaveChangesAsync();
                     status= "Employee successfully saved";
                    dbmet.InsertAuditTrail("Save Employee" + " " + status, DateTime.Now.ToString("yyyy-MM-dd"), "Employee Module", data.CreatedBy, "0");
                }
                else
                {
                   
                    var employee = _context.TblUsersModels.SingleOrDefault(a => a.Id == int.Parse(data.Id));
                    employee.UserType = int.Parse(data.UserType);
                    employee.Fullname = data.Fname + " " + data.Mname + " " + data.Lname + " " + data.Suffix;
                    employee.Active = 1;
                    employee.Fname = data.Fname;
                    employee.Lname = data.Lname;
                    employee.Mname = data.Mname;
                    employee.Position = int.Parse(data.Position);
                    employee.Suffix = data.Suffix;
                    employee.Status = int.Parse(data?.Status);
                    employee.Department = int.Parse(data.Department);
                    employee.Email = data.Email;
                    employee.Gender = data.Gender;
                    employee.DateStarted = Convert.ToDateTime(data.DateStarted);
                    employee.DateCreated = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
                    employee.CreatedBy = data.CreatedBy;
                    employee.PayrollType = int.Parse(data.PayrollType);
                    employee.SalaryType = int.Parse(data.SalaryType);
                    employee.Address = data.Address;
                    employee.FilePath = "/img/"+data.FilePath;
                    _context.Entry(employee).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }

                return Ok(status);

                
            }
            catch (Exception ex)
            {
                dbmet.InsertAuditTrail("Save Employee" + " " + ex.Message, DateTime.Now.ToString("yyyy-MM-dd"), "Employee Module", data.CreatedBy, "0");

                return Problem(ex.GetBaseException().ToString());
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> update(int id, TblUsersModel tblUserModel)
        {
            if (_context.TblUsersModels == null)
            {
                return Problem("Entity set 'ODC_HRISContext.TblUsersModels'  is null.");
            }

            var userModel = _context.TblUsersModels.AsNoTracking().Where(userModel => !userModel.DeleteFlag && userModel.Id == id).FirstOrDefault();

            if (userModel == null)
            {
                return Conflict("No records matched!");
            }

            if (id != userModel.Id)
            {
                return Conflict("Ids mismatched!");
            }

            bool hasDuplicateOnUpdate = (_context.TblUsersModels?.Any(userModel => userModel.Username == tblUserModel.Username || userModel.Email == tblUserModel.Email)).GetValueOrDefault();

            // check for duplication
            if (hasDuplicateOnUpdate)
            {
                return Conflict("Entity already exists");
            }

            try
            {
                _context.Entry(tblUserModel).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                string status = "Employee successfully updated";
                dbmet.InsertAuditTrail("Update Employee" + " " + status, DateTime.Now.ToString("yyyy-MM-dd"), "Employee Module", tblUserModel.CreatedBy, "0");

                return Ok("Update Successful!");
            }
            catch (Exception ex)
            {
                dbmet.InsertAuditTrail("Update Employee" + " " + ex.Message, DateTime.Now.ToString("yyyy-MM-dd"), "Employee Module", tblUserModel.CreatedBy, "0");
                return Problem(ex.GetBaseException().ToString());
            }
        }

        [HttpPost]
        public async Task<IActionResult> delete(DeletionModel deletionModel)
        {

            if (_context.TblUsersModels == null)
            {
                return Problem("Entity set 'ODC_HRISContext.TblUsersModels'  is null.");
            }

            var userModel = await _context.TblUsersModels.FindAsync(deletionModel.id);
            if (userModel == null || userModel.DeleteFlag)
            {
                return Conflict("No records matched!");
            }

            try
            {
                userModel.DeleteFlag = true;
                userModel.DateDeleted = DateTime.Now;
                userModel.DeletedBy = deletionModel.deletedBy;
                userModel.DateRestored = null;
                userModel.RestoredBy = "";
                _context.Entry(userModel).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                string status = "Employee successfully deleted";
                dbmet.InsertAuditTrail("Delete Employee" + " " + status, DateTime.Now.ToString("yyyy-MM-dd"), "Employee Module", deletionModel.deletedBy, "0");

                return Ok("Deletion Successful!");
            }
            catch (Exception ex)
            {
                dbmet.InsertAuditTrail("Delete Employee" + " " + ex, DateTime.Now.ToString("yyyy-MM-dd"), "Employee Module", deletionModel.deletedBy, "0");

                return Problem(ex.GetBaseException().ToString());
            }
        }

        [HttpPost]
        public async Task<IActionResult> restore(RestorationModel restorationModel)
        {

            if (_context.TblUsersModels == null)
            {
                return Problem("Entity set 'ODC_HRISContext.TblUsersModels'  is null.");
            }

            var userModel = await _context.TblUsersModels.FindAsync(restorationModel.id);
            if (userModel == null || !userModel.DeleteFlag)
            {
                return Conflict("No deleted records matched!");
            }

            try
            {
                userModel.DeleteFlag = !userModel.DeleteFlag;
                userModel.DateDeleted = null;
                userModel.DeletedBy = "";
                userModel.DateRestored = DateTime.Now;
                userModel.RestoredBy = restorationModel.restoredBy;

                _context.Entry(userModel).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                string status = "Employee successfully restored";
                dbmet.InsertAuditTrail("Restore Employee" + " " + status, DateTime.Now.ToString("yyyy-MM-dd"), "Employee Module", restorationModel.restoredBy, "0");

                return Ok("Restoration Successful!");
            }
            catch (Exception ex)
            {
                dbmet.InsertAuditTrail("Restore Employee" + " " + ex.Message, DateTime.Now.ToString("yyyy-MM-dd"), "Employee Module", restorationModel.restoredBy, "0");

                return Problem(ex.GetBaseException().ToString());
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TblUsersModel>> search(int id)
        {
            if (_context.TblUsersModels == null)
            {
                return Problem("Entity set 'ODC_HRISContext.TblUsersModels'  is null.");
            }
            var userModel = await _context.TblUsersModels.FindAsync(id);

            if (userModel == null || userModel.DeleteFlag)
            {
                return Conflict("No records found!");
            }

            string status = "Employee successfully searched";
            dbmet.InsertAuditTrail("Search Employee" + " " + status, DateTime.Now.ToString("yyyy-MM-dd"), "Employee Module", "User", "0");
            return Ok(userModel);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblUsersModel>>> view()
        {
            if (_context.TblUsersModels == null)
            {
                return Problem("Entity set 'ODC_HRISContext.TblUsersModels'  is null.");
            }

            string status = "Employee successfully viewed";
            dbmet.InsertAuditTrail("View Active Employee" + " " + status, DateTime.Now.ToString("yyyy-MM-dd"), "Employee Module", "User", "0");
            return await _context.TblUsersModels.Where(employeeModel => !employeeModel.DeleteFlag).ToListAsync();
        }
    }
}
