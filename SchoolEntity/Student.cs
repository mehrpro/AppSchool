﻿using System;


namespace SchoolEntity
{
    [SchoolDataAccess.Table("appschool","Student")]
    public class Student
    {
        [SchoolDataAccess.PrimeryKey]
        [SchoolDataAccess.ComputedColumn]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public int Code { get; set; }
        public int NatinalCode { get; set; }
        public DateTime BrithDate { get; set; }
        public DateTime DateTimeRegister { get; set; }
    }
}