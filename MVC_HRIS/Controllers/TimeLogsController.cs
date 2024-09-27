﻿
using MVC_HRIS.Models;
using CMS.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Data;

using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using MVC_HRIS.Services;
using System.Text;
using System;
using AuthSystem.Manager;
using MVC_HRIS.Manager;
using ExcelDataReader;
using System.Collections.Generic;
using OfficeOpenXml.Style;
using OfficeOpenXml;
using System.ComponentModel;
using System.Drawing;
using Net.SourceForge.Koogra.Excel2007.OX;
using MVC_HRIS.Models;
using MVC_HRIS.Services;
using API_HRIS.Manager;
using Microsoft.EntityFrameworkCore;
using MVC_HRIS.Models;
using System.Net;

namespace MVC_HRIS.Controllers
{
    public class TimeLogsController : Controller
    {
        string status = "";
        private readonly QueryValueService token;
        private readonly AppSettings _appSettings;
        private ApiGlobalModel _global = new ApiGlobalModel();
        DbManager db = new DbManager();
        public readonly QueryValueService token_;
        private IConfiguration _configuration;
        private string apiUrl = "http://";
        public TimeLogsController(IOptions<AppSettings> appSettings,  QueryValueService _token,
                  IHttpContextAccessor contextAccessor,
                  IConfiguration configuration)
        {
            token_ = _token;
            _configuration = configuration;
            apiUrl = _configuration.GetValue<string>("AppSettings:WebApiURL");
            _appSettings = appSettings.Value;
        }
        
        public IActionResult Index()
        {//update
            string token = HttpContext.Session.GetString("Bearer");
            if (token == "")
            {
                return RedirectToAction("Index", "LogIn");
            }
            return View();
        }
        public class TimeLogsParam
        {
            public string? Usertype { get; set; }
            public string? UserId { get; set; }
        }
        public partial class User
        {
            public int? UserId { get; set; }

            //

        }
        [HttpPost]
        public async Task<IActionResult> GetLastTimeIn(User data)
        {
            string res = "";
            try
            {

                HttpClient client = new HttpClient();
                var url = DBConn.HttpString + "/TimeLogs/getLastTimeIn";

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token_.GetValue());
                StringContent content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
                using (var response = await client.PostAsync(url, content))
                {
                    HttpStatusCode statusCode = response.StatusCode;
                    res = await response.Content.ReadAsStringAsync();
                    
                }

            }

            catch (Exception ex)
            {
                status = ex.GetBaseException().ToString();
            }
            return Json(new { status = res });
        }
        [HttpPost]
        public async Task<IActionResult> TimeOut(User data)
        {
            string res = "";
            try
            {

                HttpClient client = new HttpClient();
                var url = DBConn.HttpString + "/TimeLogs/TimeOut";

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token_.GetValue());
                StringContent content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
                using (var response = await client.PostAsync(url, content))
                {
                    HttpStatusCode statusCode = response.StatusCode;
                    int numericStatusCode = (int)statusCode;
                    if (numericStatusCode == 200)
                    {
                        res = numericStatusCode.ToString();
                    }
                    else
                    {
                        res = await response.Content.ReadAsStringAsync();
                    }
                }

            }

            catch (Exception ex)
            {
                status = ex.GetBaseException().ToString();
            }
            return Json(new { status = res });
        }
        [HttpPost]
        public async Task<IActionResult> GetTimelogsList(TimeLogsParam data)
        {
            string result = "";
            var list = new List<TimelogsVM>();
            try
            {
                HttpClient client = new HttpClient();
                var url = DBConn.HttpString + "/TimeLogs/TimeLogsList";
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token_.GetValue());
                StringContent content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
                using (var response = await client.PostAsync(url, content))
                {
                    string res = await response.Content.ReadAsStringAsync();
                    list = JsonConvert.DeserializeObject<List<TimelogsVM>>(res);

                }
            }

            catch (Exception ex)
            {
                string status = ex.GetBaseException().ToString();
            }

            return Json(new { draw = 1, data = list, recordFiltered = list?.Count, recordsTotal = list?.Count });
        }
        [HttpPost]
        public async Task<IActionResult> TimeIn(TblTimeLog data)
        {
            string res = "";
            try
            {
          
                HttpClient client = new HttpClient();
                var url = DBConn.HttpString + "/TimeLogs/TimeIn";
              
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token_.GetValue());
                StringContent content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
                using (var response = await client.PostAsync(url, content))
                {
                    HttpStatusCode statusCode = response.StatusCode;
                    int numericStatusCode = (int)statusCode;
                    if (numericStatusCode == 200)
                    {
                        res = numericStatusCode.ToString();
                    }
                    else
                    {
                        res = await response.Content.ReadAsStringAsync();
                    }
                }

            }

            catch (Exception ex)
            {
                 status = ex.GetBaseException().ToString();
            }
          return Json(new { status = res });
        }

        public IActionResult TaskModal()
        {
           
               
                return PartialView("TaskModal");
        }
    }
}
