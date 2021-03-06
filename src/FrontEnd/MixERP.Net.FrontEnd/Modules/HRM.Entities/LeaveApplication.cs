// ReSharper disable All
/********************************************************************************
Copyright (C) MixERP Inc. (http://mixof.org).

This file is part of MixERP.

MixERP is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, version 2 of the License.


MixERP is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with MixERP.  If not, see <http://www.gnu.org/licenses/>.
***********************************************************************************/
// ReSharper disable All
using PetaPoco;
using System;

namespace MixERP.Net.Entities.HRM
{
    [PrimaryKey("leave_application_id", autoIncrement = true)]
    [TableName("hrm.leave_applications")]
    [ExplicitColumns]
    public sealed class LeaveApplication : PetaPocoDB.Record<LeaveApplication>, IPoco
    {
        [Column("leave_application_id")]
        [ColumnDbType("int8", 0, false, "nextval('hrm.leave_applications_leave_application_id_seq'::regclass)")]
        public long LeaveApplicationId { get; set; }

        [Column("employee_id")]
        [ColumnDbType("int4", 0, false, "")]
        public int EmployeeId { get; set; }

        [Column("leave_type_id")]
        [ColumnDbType("int4", 0, false, "")]
        public int LeaveTypeId { get; set; }

        [Column("entered_by")]
        [ColumnDbType("int4", 0, false, "")]
        public int EnteredBy { get; set; }

        [Column("applied_on")]
        [ColumnDbType("date", 0, true, "")]
        public DateTime? AppliedOn { get; set; }

        [Column("reason")]
        [ColumnDbType("text", 0, true, "")]
        public string Reason { get; set; }

        [Column("start_date")]
        [ColumnDbType("date", 0, true, "")]
        public DateTime? StartDate { get; set; }

        [Column("end_date")]
        [ColumnDbType("date", 0, true, "")]
        public DateTime? EndDate { get; set; }

        [Column("audit_user_id")]
        [ColumnDbType("int4", 0, true, "")]
        public int? AuditUserId { get; set; }

        [Column("audit_ts")]
        [ColumnDbType("timestamptz", 0, true, "")]
        public DateTime? AuditTs { get; set; }
    }
}