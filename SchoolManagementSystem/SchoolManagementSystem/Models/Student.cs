﻿namespace SchoolManagementSystem.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public List<Qualification> Qualifications { get; set; } = new List<Qualification>();  // Allow multiple qualifications
    }

    public class Qualification
    {
        public string CourseName { get; set; }
        public float Percentage { get; set; }
        public int YearOfPassing { get; set; }
    }

}
