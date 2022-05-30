using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inf107_2_
{
    public class Linq2
    {
        public class School
        {
            public string NameSchool { get; set; }
            public int IdSchool { get; set; }
            public int AgeSchool { get; set; }
            public int SchoolPerfomance { get; set; }//по 10-бальной шкале
        }
        public class District
        {
            public string NameDistrict { get; set; }
            public int IdDistrict { get; set; }

        }
        public class SchoolidDistrict
        {
            public School School { get; set; }
            public District District { get; set; }
        }
        //public class NameSchoolANDidDistrict
        //{
        //    public string NameSchool2 { get; set; }
        //    public int IdDistrict { get; set; }
        //}
        public void Run()
        {
            var school = new List<School>
            {
                new School { IdSchool = 1, NameSchool = "Школа N1", AgeSchool=5, SchoolPerfomance=4 },
                new School { IdSchool = 2, NameSchool = "Школа N2", AgeSchool=10, SchoolPerfomance=4 },
                new School { IdSchool = 3, NameSchool = "Школа N3", AgeSchool=15, SchoolPerfomance=7 },
                new School { IdSchool = 4, NameSchool = "Школа N4", AgeSchool=20, SchoolPerfomance=9 },
                new School { IdSchool = 5, NameSchool = "Школа N5", AgeSchool=25, SchoolPerfomance=6 },
                new School { IdSchool = 6, NameSchool = "Школа N6", AgeSchool=30, SchoolPerfomance=3},
                new School { IdSchool = 7, NameSchool = "Школа N7", AgeSchool=35, SchoolPerfomance=10 },
                new School { IdSchool = 8, NameSchool = "Школа N8", AgeSchool=40, SchoolPerfomance=2 },
                new School { IdSchool = 9, NameSchool = "Школа N9", AgeSchool=45, SchoolPerfomance=8 },
                new School { IdSchool = 10, NameSchool = "Школа N10" , AgeSchool=50, SchoolPerfomance=9}
            };
            School[] school2 =
            {
                new School { IdSchool = 1, NameSchool = "Школа N1", AgeSchool=5, SchoolPerfomance=4 },
                new School { IdSchool = 2, NameSchool = "Школа N2", AgeSchool=10, SchoolPerfomance=4 },
                new School { IdSchool = 3, NameSchool = "Школа N3", AgeSchool=15, SchoolPerfomance=7 },
                new School { IdSchool = 4, NameSchool = "Школа N4", AgeSchool=20, SchoolPerfomance=9 },
                new School { IdSchool = 5, NameSchool = "Школа N5", AgeSchool=25, SchoolPerfomance=6 },
                new School { IdSchool = 6, NameSchool = "Школа N6", AgeSchool=30, SchoolPerfomance=3},
                new School { IdSchool = 7, NameSchool = "Школа N7", AgeSchool=35, SchoolPerfomance=10 },
                new School { IdSchool = 8, NameSchool = "Школа N8", AgeSchool=40, SchoolPerfomance=2 },
                new School { IdSchool = 9, NameSchool = "Школа N9", AgeSchool=45, SchoolPerfomance=8 },
                new School { IdSchool = 10, NameSchool = "Школа N10" , AgeSchool=50, SchoolPerfomance=9}
            };
            District[] district2=
            {
                new District { IdDistrict = 1, NameDistrict = "Ново-Савиновский р-н"},
                new District { IdDistrict = 2, NameDistrict = "Советский р-н"},
                new District { IdDistrict = 3, NameDistrict = "Вахитовский р-н"},
                new District { IdDistrict = 4, NameDistrict = "Приволжский р-н"},
                new District { IdDistrict = 5, NameDistrict = "Кировский р-н"},
            };
            var district = new List<District>
            {
                new District { IdDistrict = 1, NameDistrict = "Ново-Савиновский р-н"},
                new District { IdDistrict = 2, NameDistrict = "Советский р-н"},
                new District { IdDistrict = 3, NameDistrict = "Вахитовский р-н"},
                new District { IdDistrict = 4, NameDistrict = "Приволжский р-н"},
                new District { IdDistrict = 5, NameDistrict = "Кировский р-н"},
            };
            var res = school.Join(district,
                p=>p.NameSchool,
                c=>c.NameDistrict,
                (p,c)=>new {Name })
            foreach (var r in res)
            {
                Console.WriteLine($"{res.Nam}");
            }
            //var res = school
            //    .Select(x => new NameSchoolANDidDistrict()
            //    {
            //        NameSchool2 = x.NameSchool2,
            //        IdDistrict = x.IdD
            //    }).ToList();
        }
    }
}
