﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace API_HRIS.Models;

public partial class TblUserType
{
    public int Id { get; set; }

    public string UserType { get; set; }

    public DateTime? DateCreated { get; set; }

    public string CreatedBy { get; set; }

    public int? Status { get; set; }

    public DateTime? DateUpdated { get; set; }

    public string UpdatedBy { get; set; }

    public DateTime? DateDeleted { get; set; }

    public string DeletedBy { get; set; }

    public DateTime? DateRestored { get; set; }

    public string RestoredBy { get; set; }
}