using Dapper.Contrib.Extensions;
using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Linq;

namespace condofy_challenge_API.Domain.Entities
{
    [Table("funcionarios")]
    public class FuncionarioEntity : EntityBase
    {
        public FuncionarioEntity(int id,
                                 string name,
                                 DateTime birthDay,
                                 decimal salary,
                                 string gender,
                                 DateTime hiringDate,
                                 string level)
        {
            Id = id;
            Name = name;
            Gender = gender;
            BirthDay = birthDay;
            Salary = salary;
            HiringDate = hiringDate;
            Level = level;
            Validate();
        }

        [ExplicitKey]
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Gender { get; private set; }
        public DateTime BirthDay { get; private set; }
        public decimal Salary { get; private set; }
        public DateTime HiringDate { get; private set; }
        public string Level { get; private set; }

        public void Validate()
        {
            new AddNotifications<FuncionarioEntity>(this)
                .IfLowerOrEqualsThan(Id, 0, "Id must be greater than zero")
                .IfNullOrEmpty(Name, "Name is obligatory")
                .IfNullOrEmpty(Gender, "Gender is obligatory")
                .IfNullOrEmpty(BirthDay.ToString(), "BirthDay is obligatory")
                .IfNullOrEmpty(Salary.ToString(), "Salary is obligatory")
                .IfNullOrEmpty(Level, "Level is obligatory")
                .IfNullOrEmpty(HiringDate.ToString(), "HiringDate is obligatory")
                .IfLengthGreaterThan(Name, 64, "Name must be a maximum of 64 characters")
                .IfLengthGreaterThan(Gender, 1, "Gender must be a maximum of 1 characters")
                .IfGreaterOrEqualsThan(BirthDay, DateTime.Now, "BirthDay must be smaller than today")
                .IfLowerOrEqualsThan(Salary, 800, "Salary must be greater than R$ 800,00")
                .IfLengthGreaterThan(Level, 1, "Level must be a maximum of 1 characters")
                .IfGreaterThan(HiringDate, DateTime.Now, "HiringDate must be less than or equals today");

            if (!new string[] { "F", "M" }.Contains(Gender))
                AddNotification("Gender", "Gender should be M or F");

            if (!new string[] { "J", "P","S" }.Contains(Level))
                AddNotification("Level", "Level should be J, P or S");
        }
    }
}
