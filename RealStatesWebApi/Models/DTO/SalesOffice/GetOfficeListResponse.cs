﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO.SalesOffice
{
    public class GetOfficeListResponse
    {
        public Guid OfficeId { get; set; }
        public string OfficeName { get; set; }

    }
}
