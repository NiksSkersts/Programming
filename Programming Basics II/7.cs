using System;
using System.Linq;

namespace I_demand_a_divorce_with_programming
//jk, jk. We stan programming. C/C++ could be cooler tho.
//this thing basically begs for a database
// I sometimes regret taking huge descriptive names for everything.
{
    internal class Program
    {
        public static void Main()
        {
            Console.Clear();
            var p = new Program();
            school_course[] courses_in_edu_est;
            Console.Write("Courses in school: ");
            var array_size_course = Convert.ToInt32(Console.ReadLine());
            courses_in_edu_est = new school_course[array_size_course];
            for (var i = 0; i < array_size_course; i++)
            {
                courses_in_edu_est[i] = new school_course();
                courses_in_edu_est[i].sc_input();
            }

            for (var i = 0; i < array_size_course; i++)
            {
                Console.Clear();
                courses_in_edu_est[i].sc_output();
                Console.Clear();
            }

            Console.WriteLine("Which course do you want to find?");
            var search_course_name = Console.ReadLine();

            if (search_for_course(courses_in_edu_est, search_course_name) == null)
            {
                Console.WriteLine("Course not found :((");
                Console.WriteLine("press any key to start again");
                Console.ReadLine();
                Main();
            }
        }

        public static school_course search_for_course(school_course[] courses_in_edu_est, string search_course_name)
        {
            var p = new Program();
            for (var i = 0; i < courses_in_edu_est.Length; i++)
                if (courses_in_edu_est[i].school_course_name.ToUpper() == search_course_name.ToUpper())
                {
                    Console.WriteLine("Oldest Scholar in course : ");
                    courses_in_edu_est[i].course_eldest_scholar();
                    Console.WriteLine("Which Scholar are you looking for?");
                    var scholars_name_surname = Console.ReadLine();
                    courses_in_edu_est[i].search_scholar(scholars_name_surname);
                    return courses_in_edu_est[i];
                }

            return null;
        }
    }

    internal class Scholar
    {
        public string scholar_name;
        public string scholar_surname;
        private string national_ident_code;

        public void scholar_input()
        {
            Console.WriteLine();
            Console.Write("Scholars' Name : ");
            scholar_name = Console.ReadLine();
            Console.Write("Scholars' Surname : ");
            scholar_surname = Console.ReadLine();
            Console.Write("Scholars' National Identity Code : ");
            national_ident_code = Console.ReadLine();
            Console.WriteLine();
        }

        public void scholar_output()
        {
            Console.WriteLine();
            Console.Write("Scholars' Name : " + scholar_name);
            Console.WriteLine();
            Console.Write("Scholars' Surname : " + scholar_surname);
            Console.WriteLine();
            Console.Write("Scholars' National Identity Code : " + national_ident_code); //EU is not impressed
            Console.WriteLine();
            Console.Write("Scholars' Age : " + scholar_age());
            Console.WriteLine();
        }

        public int scholar_age()
        {
            var get_year = new int[2];
            var get_month = new int[2];
            var get_day = new int[2];
            var year = (int) DateTime.Now.Year;
            var month = (int) DateTime.Now.Month;
            var day = (int) DateTime.Now.Day;
            for (var i = 0; i <= 1; i++)
                get_year[i] = national_ident_code[i + 4] - '0';
            //this actually works .... Danke Stack.
            for (var i = 0; i <= 1; i++) get_month[i] = national_ident_code[i + 2] - '0';
            for (var i = 0; i <= 1; i++) get_day[i] = national_ident_code[i] - '0';
            var by = int.Parse(string.Concat(get_year));
            var bm = int.Parse(string.Concat(get_month));
            var bd = int.Parse(string.Concat(get_day));
            //for this "if" bundle to fail to recognize the correct year, a person would have to been born at 1920. 
            //I mean, a person who was born @1920 is probably very dead and if that person is still alive, well, at 120, going to school ain't gonna be his first priority.
            if (by + 2000 > year)
                @by = @by + 1900;
            else
                @by = @by + 2000;
            by = year - by;
            if (bm > month) @by--;
            if (bm == month)
                if (bd > day)
                    @by--;

            return by;
        }
    }

    internal class Teacher
    {
        private string teacher_name;
        private string teacher_surname;
        private double teacher_wage;

        public void teacher_input()
        {
            Console.WriteLine();
            Console.Write("Teachers' Name : ");
            teacher_name = Console.ReadLine();
            Console.Write("Teachers' Surname : ");
            teacher_surname = Console.ReadLine();
            Console.Write("Teachers' wage : ");
            teacher_wage = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine();
        }

        public void teacher_output()
        {
            Console.WriteLine();
            Console.Write("Head teachers' Name : " + teacher_name);
            Console.WriteLine();
            Console.Write("Teachers' Surname : " + teacher_surname);
            Console.WriteLine();
            Console.Write("Teachers' Salary : " + teacher_wage_neto());
            Console.WriteLine();
        }

        public double teacher_wage_neto()
        {
            var teacher_wage_neto = teacher_wage - teacher_wage * 0.23; //It was 23% on avg, wasn't it?
            return teacher_wage_neto;
        }
    }

    internal class school_course
    {
        public string school_course_name;
        public int count_scholar;
        public Scholar[] scholars_in_course;
        public Teacher teacher_of_the_course = new();

        public void sc_input()
        {
            Console.WriteLine();
            Console.Write("Course name : "); //Dvdz FTW
            school_course_name = Console.ReadLine();
            Console.Write("Scholar count : ");
            count_scholar = Convert.ToInt32(Console.ReadLine());
            teacher_of_the_course.teacher_input();
            scholars_in_course = new Scholar[count_scholar];
            for (var i = 0; i < count_scholar; i++)
            {
                scholars_in_course[i] = new Scholar();
                scholars_in_course[i].scholar_input();
            }

            Console.WriteLine();
        }

        public void sc_output()
        {
            Console.WriteLine("Name of the course : " + school_course_name);
            Console.WriteLine("Scholar count : " + count_scholar);
            teacher_of_the_course.teacher_output();
            Console.WriteLine();
            for (var i = 0; i < count_scholar; i++) scholars_in_course[i].scholar_output();
            Console.WriteLine();
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
        }

        public void course_eldest_scholar()
        {
            if (count_scholar == 0)
            {
                Console.WriteLine("Course has no scholars!");
            }
            else
            {
                var index = 0;
                var max_age = 0;
                for (var i = 0; i < count_scholar; i++)
                    if (scholars_in_course[i].scholar_age() > max_age)
                    {
                        index = i;
                        max_age = scholars_in_course[i].scholar_age();
                    }

                scholars_in_course[index].scholar_output();
            }
        }

        public void search_scholar(string scholars_name_surname)
        {
            var index = -1;
            for (var i = 0; i < count_scholar; i++)
                if (scholars_in_course[i].scholar_name.ToUpper() == scholars_name_surname.ToUpper() ||
                    scholars_in_course[i].scholar_surname.ToUpper() == scholars_name_surname.ToUpper())
                    index = i;
            if (index == -1)
                Console.WriteLine("Scholar not found :((");
            else
                scholars_in_course[index].scholar_output();
            Console.WriteLine();
            Console.WriteLine("Press any key to start again");
            Console.ReadLine();
            Program.Main();
        }
    }
}