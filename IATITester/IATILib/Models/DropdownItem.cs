﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IATITester.IATILib.Models
{
    [Serializable]
    public enum ExecutingAgencyType
    {
        Government = 1,
        DP = 2,
        NGO = 3,
        Others = 4
    }

    public class DropdownItem
    {
        [Serializable]
        public class DPLookupItem
        {
            public string ID { get; set; }
            public string Name { get; set; }
            public int AimsFundSourceId { get; set; }
            public int FundSourceCategoryId { get; set; }
            public string IDnIATICode { get { return AimsFundSourceId + "~" + (ID ?? ""); } }

            public string AllID
            {
                get
                {
                    return AimsFundSourceId + "~"
                    + (ID ?? "") + "~"
                    + (int)ExecutingAgencyType.DP + "~"
                    + FundSourceCategoryId;
                }
            }
        }

        [Serializable]
        public class FundSourceLookupItem
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string IATICode { get; set; }
            public string IDnIATICode { get { return ID + "~" + (IATICode ?? ""); } }
            public bool IsManagingDP { get; set; }
        }

        [Serializable]
        public class ExecutingAgencyLookupItem
        {
            public string AllID
            {
                get
                {
                    return ExecutingAgencyOrganizationId + "~"
    + (IATICode ?? "") + "~"
    + (ExecutingAgencyTypeId ?? 0) + "~"
    + ExecutingAgencyOrganizationTypeId;
                }
            }

            private int? _ExecutingAgencyTypeId;

            public int ExecutingAgencyOrganizationId { get; set; }
            public int? ExecutingAgencyTypeId { get { return _ExecutingAgencyTypeId ?? 4; } set { _ExecutingAgencyTypeId = value; } }
            public int ExecutingAgencyOrganizationTypeId { get; set; }

            public string Name { get; set; }
            public string IATICode { get; set; }
            public string IDnIATICode { get { return ExecutingAgencyOrganizationId + "~" + (IATICode ?? ""); } }

        }

        [Serializable]
        public class LookupItem
        {
            public int ID { get; set; }
            public string Name { get; set; }
        }

        [Serializable]
        public class CurrencyLookupItem
        {
            public int Id { get; set; }
            public string IATICode { get; set; }
        }

        [Serializable]
        public class AidCategoryLookupItem
        {
            public int Id { get; set; }
            public string IATICode { get; set; }
        }
    }
}
