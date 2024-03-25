﻿using KaleGroup.Data.Abstract;

namespace KaleGroup.Data.Entities
{
    public class FooterMenus :ModelBase
    {
        public string? PageName { get; set; }
        public string? EnPageName { get; set; }
        public string? PageUrl { get; set; }
        public string? EnPageUrl { get; set; }
        public string? FileUrl { get; set; }
        public string? EnFileUrl { get; set; }        
        public bool   IsActive { get; set; }
        public string? Description { get; set; }
        public string? EnDescription { get; set; }
        public int OrderNumber { get; set; }
        public string? PageTopSubject { get; set; }
        public string? PageTopDescription { get; set; }
        public string? PageTopBackground { get; set; }
        public string? EnPageTopSubject { get; set; }
        public string? EnPageTopDescription { get; set; }
    }
}

 






 


