using EFCoreLoadings.Contexts;
using EFCoreLoadings.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
Console.OutputEncoding = System.Text.Encoding.UTF8;

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();
    
var optionsBuilder = new DbContextOptionsBuilder<AuthDbContext>();
optionsBuilder.UseSqlServer(configuration.GetConnectionString("Default"));

using (var context = new AuthDbContext(optionsBuilder.Options))
{

    /*Задание 1: Связь Student → StudentProfile (один к одному).
    - Напиши Fluent API для всех необходимых связей
        - Реализуй два запроса: один с Eager Loading, второй с Explicit Loading*/

    /*var student =  context.Students.FirstOrDefault();

    context.Entry(student).Reference(s => s.StudentProfile).Load();

    Console.WriteLine($"{student.Name} → {student.StudentProfile?.Adress}");
    ////////////////////////////////////////////////////////////////////////////
    var studentProfile =

        context.Students.Include(s => s.StudentProfile).ToList();

    foreach (var s in studentProfile)
    {
        Console.WriteLine($"{s.Name}");
    }*/

    /*Задание 2: Связь Student → Enrollment → Course (многие ко многим через Enrollment).
    - Напиши Fluent API для всех необходимых связей
        - Реализуй два запроса: один с Eager Loading, второй с Explicit Loading*/

    /*var student1 = context.Students.FirstOrDefault();

    context.Entry(student1).Collection(s => s.Enrollments).Load();

    foreach (var enrollment in student1.Enrollments)
    {
        context.Entry(enrollment)
            .Reference(e => e.Course)
            .Load();
    }

    Console.WriteLine($"{student1.Name}:");
    foreach (var enrollment in student1.Enrollments)
    {
        Console.WriteLine($"  - {enrollment.Course.Title}");
    }*/

    ////////////////////////////////////////////////////////////////
    /*var studentsWithCourses = context.Students
        .Include(s => s.Enrollments)
        .ThenInclude(e => e.Course)
        .ToList();

    foreach (var student in studentsWithCourses)
    {
        Console.WriteLine($"{student.Name}:");
        foreach (var enrollment in student.Enrollments)
        {
            Console.WriteLine($"  - {enrollment.Course.Title}");
        }
    }*/
    /*Задание 3: Связь Instructor → CourseAssignment → Course (многие ко многим).
    - Напиши Fluent API для всех необходимых связей
        - Реализуй два запроса: один с Eager Loading, второй с Explicit Loading*/

    /*var instructor = context.Instructors.FirstOrDefault();

    context.Entry(instructor).Collection(i => i.CourseAssignments).Load();

    foreach (var i in instructor.CourseAssignments)
    {
        context.Entry(i).Reference(i => i.Course).Load();
    }

    Console.WriteLine($"{instructor.Name}:");
    foreach (var i in instructor.CourseAssignments)
    {
        Console.WriteLine($"  - {i.Course.Title}");
    }


    var intructorWithCourses = context.Instructors
        .Include(i => i.CourseAssignments).ThenInclude(c => c.Course).ToList();

    foreach (var i in intructorWithCourses)
    {
        Console.WriteLine($"{i.Name}:");
        foreach (var course in i.CourseAssignments)
        {
            Console.WriteLine($"  - {course.Course.Title}");
        }
    }*/
    
    /*Задание 4: Instructor → OfficeAssignment (один к одному).
    - Напиши Fluent API для всех необходимых связей
        - Реализуй два запроса: один с Eager Loading, второй с Explicit Loading*/
    
    /*var instructor1 = context.Instructors.FirstOrDefault();
    
    context.Entry(instructor1).Collection(i => i.CourseAssignments).Load();

    foreach (var i in instructor1.CourseAssignments)
    {
        context.Entry(i).Reference(i => i.Course).Load();
    }
    
    Console.WriteLine($"{instructor1.Name}:");
    foreach (var i in instructor1.CourseAssignments)
    {
        Console.WriteLine($"  - {i.Course.Title}");
    }
    
    var instrtorWithCourses = context.Instructors
        .Include(i => i.CourseAssignments)
        .ThenInclude(c => c.Course).ToList();

    foreach (var i in instrtorWithCourses)
    {
        Console.WriteLine($"{i.Name}:");
        foreach (var course in i.CourseAssignments)
        {
            Console.WriteLine($"  - {course.Course.Title}");
        }
    }*/
    
    /*Задание 5: Course → Department (многие к одному).
    - Напиши Fluent API для всех необходимых связей
        - Реализуй два запроса: один с Eager Loading, второй с Explicit Loading*/
    
    var course1 = context.Courses.First();

    context.Entry(course1)
        .Reference(c => c.Department)
        .Load();

    Console.WriteLine($"{course1.Title} → {course1.Department?.Name}");
    
    var course2 = context.Courses.Include(c => c.Department).ToList();

    foreach (var course in course2)
    {
        Console.WriteLine(course.Title);
    }
    
    /*Задание 6: Exam → Course (многие к одному).
    - Напиши Fluent API для всех необходимых связей
        - Реализуй два запроса: один с Eager Loading, второй с Explicit Loading*/
    var coursesWithExams = context.Courses
        .Include(c => c.Exams)
        .ToList();

    foreach (var course in coursesWithExams)
    {
        Console.WriteLine($"Course: {course.Title}");
        foreach (var exam in course.Exams)
        {
            Console.WriteLine($"   Exam: {exam.MaxScore}");
        }
    }
    
    var course12 = context.Courses.First();

    context.Entry(course12)
        .Collection(c => c.Exams)
        .Load();

    Console.WriteLine($"Course: {course12.Title}");
    foreach (var exam in course1.Exams)
    {
        Console.WriteLine($"   Exam: {exam.MaxScore}");
    }
    /*Задание 7: ExamResult → Exam + Student (двойная связь).
    - Напиши Fluent API для всех необходимых связей
        - Реализуй два запроса: один с Eager Loading, второй с Explicit Loading*/
    
    var examResultWithDetails = context.ExamResults
        .Include(er => er.Exam)
        .Include(er => er.Student)
        .ToList();


    foreach (var examResult in examResultWithDetails)
    {
        Console.WriteLine($"{examResult.Student.Name} - {examResult.Exam.MaxScore}");
    }
    
    var examRes = context.ExamResults.ToList();
    
    foreach (var examResult in examRes)
    {
        context.Entry(examResult).Reference(er => er.Exam).Load();
        context.Entry(examResult).Reference(er => er.Student).Load();

        Console.WriteLine($"{examResult.Student.Name} - {examResult.Exam.MaxScore}");
    }
    
    /*Задание 8: Department → Instructor (один ко многим).
    - Напиши Fluent API для всех необходимых связей
        - Реализуй два запроса: один с Eager Loading, второй с Explicit Loading*/

    var depWithInstructors = context.Departments
        .Include(d => d.Instructors).ToList();

    foreach (var dep in depWithInstructors)
    {
        Console.WriteLine($"{dep.Name}");
        foreach (var instructor in dep.Instructors)
        {
            Console.WriteLine($"   Instructor: {instructor.Name}");
        };
    }
    
    var depFirst =  context.Departments.First();    
    
    context.Entry(depFirst).Collection(d => d.Instructors).Load();
    
    Console.WriteLine($"{depFirst.Name}");

    foreach (var instructor in depFirst.Instructors)
    {
        Console.WriteLine($"   Instructor: {instructor.Name}");
    }
    
    /*Задание 9: Student → Enrollment → Course → Exam (цепочка).
    - Напиши Fluent API для всех необходимых связей
        - Реализуй два запроса: один с Eager Loading, второй с Explicit Loading*/

    var studentInfo = context.Students
        .Include(s => s.Enrollments)
        .ThenInclude(e => e.Course)
        .ThenInclude(c => c.Exams)
        .ToList();

    foreach (var student in studentInfo)
    {
        Console.WriteLine($"Student: {student.Name}");
        foreach (var enrollment in student.Enrollments)
        {
            Console.WriteLine($"  Course: {enrollment.Course.Title}");
            foreach (var exam in enrollment.Course.Exams)
            {
                Console.WriteLine($"    Exam: {exam.Date}");
            }
        }
    }
    
    var studentFirst = context.Students.First();

    context.Entry(studentFirst).Collection(s => s.Enrollments).Load();

    foreach (var enrollment in studentFirst.Enrollments)
    {
        context.Entry(enrollment).Reference(e => e.Course).Load();
        context.Entry(enrollment.Course).Collection(c => c.Exams).Load();

        Console.WriteLine($"Student: {studentFirst.Name}");
        Console.WriteLine($"  Course: {enrollment.Course.Title}");
        foreach (var exam in enrollment.Course.Exams)
        {
            Console.WriteLine($"    Exam: {exam.Date}");
        }
    }
    
    /*Задание 10: Course → Exam → ExamResult → Student (обратная цепочка).
    - Напиши Fluent API для всех необходимых связей
        - Реализуй два запроса: один с Eager Loading, второй с Explicit Loading*/

    var courseInfo = context.Courses
        .Include(e => e.Exams)
        .ThenInclude(eres => eres.ExamResults)
        .ThenInclude(s => s.Student).ToList();

    foreach (var course in courseInfo)
    {
        Console.WriteLine($"Course: {course.Title}");
        foreach (var exam in course.Exams)
        {
            Console.WriteLine($"   Exam: {exam.MaxScore}");
            foreach (var examResult in exam.ExamResults)
            {
                Console.WriteLine($"   Exam: {examResult.Student.Name}");
            }
        }
    }
    
    var courseFirst =  context.Courses.First();
    
    context.Entry(courseFirst).Collection(s => s.Exams).Load();

    foreach (var exam in courseFirst.Exams)
    {
        context.Entry(exam).Collection(e => e.ExamResults).Load();

        foreach (var examResult in exam.ExamResults)
        {
            context.Entry(examResult).Reference(er => er.Student).Load();

            Console.WriteLine($"{examResult.Student.Name}");
        }
    }
    
    /*Задание 11: Instructor → Course → Exam (через CourseAssignment).
    - Напиши Fluent API для всех необходимых связей
        - Реализуй два запроса: один с Eager Loading, второй с Explicit Loading*/
    
    var instructorInfo = context.Instructors
        .Include(i => i.CourseAssignments)
        .ThenInclude(c => c.Course)
        .ThenInclude(e => e.Exams).ToList();

    foreach (var instructor in instructorInfo)
    {
        Console.WriteLine($"Instructor: {instructor.Name}");
        foreach (var assignment in instructor.CourseAssignments)
        {
            Console.WriteLine($"  Course: {assignment.Course.Title}");
            foreach (var exam in assignment.Course.Exams)
            {
                Console.WriteLine($"    MaxScore: {exam.MaxScore}");
            }
        }
    }
    
    var instructorFirst = context.Instructors.First();
    context.Entry(instructorFirst).Collection(i => i.CourseAssignments).Load();

    foreach (var instructor in instructorFirst.CourseAssignments)
    {
        context.Entry(instructor).Reference(i => i.Course).Load();
        context.Entry(instructor.Course).Collection(i => i.Exams).Load();
    }
    
    Console.WriteLine($"Instructor: {instructorFirst.Name}");

    foreach (var instructor in instructorFirst.CourseAssignments)
    {
        Console.WriteLine($"  Course: {instructor.Course.Title}");
        foreach (var exam in instructor.Course.Exams)
        {
            Console.WriteLine($"{exam.MaxScore}");
        }
    }

    /*Задание 12: Получить студентов, у которых был экзамен по конкретному курсу.
    - Напиши Fluent API для всех необходимых связей
        - Реализуй два запроса: один с Eager Loading, второй с Explicit Loading*/

    var studentInfo1 = context.Students
        .Include(e => e.Enrollments)
        .ThenInclude(c => c.Course)
        .ThenInclude(e => e.Exams)
        .ToList();

    foreach (var student in studentInfo1)
    {
        foreach (var enrollment in student.Enrollments)
        {
            if (enrollment.Course.Title == "Math")
            {
                Console.WriteLine($"  Student: {student.Name}");
            }
        }
    }
    
    var studentFirst1 =  context.Students.First();
    
    context.Entry(studentFirst1).Collection(s => s.Enrollments).Load();

    foreach (var enrollment in studentFirst1.Enrollments)
    {
        context.Entry(enrollment).Reference(e => e.Course).Load();
        context.Entry(enrollment.Course).Collection(c => c.Exams).Load();
    }

    foreach (var enrollment in studentFirst1.Enrollments)
    {
        if (enrollment.Course.Title == "Math")
        {
            Console.WriteLine($"  Student: {studentFirst1.Name}");
        }
    }
    
    /*Задание 13: Получить курсы без экзаменов.
    - Напиши Fluent API для всех необходимых связей
        - Реализуй два запроса: один с Eager Loading, второй с Explicit Loading*/
    
    var allCourses = context.Courses
        .Include(c => c.Exams)  
        .ToList();

    foreach (var course in allCourses)
    {
        if (!course.Exams.Any())
        {
            Console.WriteLine($"  Course without exams: {course.Title}");
        }
    }
    
    var courseFirst1 = context.Courses.ToList();
    

    foreach (var course in courseFirst1)
    {
        context.Entry(course).Collection(c => c.Exams).Load();

        if (!course.Exams.Any())
        {
            Console.WriteLine($"Course without exams: {course.Title}");
        }
    }
    
    /*Задание 14: Получить студентов с количеством сданных экзаменов > 3.
    - Напиши Fluent API для всех необходимых связей
        - Реализуй два запроса: один с Eager Loading, второй с Explicit Loading*/

    var studentFirst2 = context.Students
        .Include(e => e.ExamResults)
        .ThenInclude(s => s.Student).ToList();

    foreach (var student in studentFirst2)
    {
        foreach (var exam in student.ExamResults)
        {
            if (exam.Score > 3)
            {
                Console.WriteLine($"  Student: {student.Name}");
            }
        }
    }
    
    var courseFirst2 = context.Students.ToList();

    foreach (var student in courseFirst2)
    {
        context.Entry(student).Collection(c => c.ExamResults).Load();
        foreach (var examResult in student.ExamResults)
        {
            if (examResult.Score > 3)
            {
                Console.WriteLine($"  Course: {student.Name}");
            }
        }
    }
    
    /*
    Задание 15: Получить всех преподавателей, у которых нет назначенных курсов.
    - Напиши Fluent API для всех необходимых связей
        - Реализуй два запроса: один с Eager Loading, второй с Explicit Loading*/
    
    var instructorInfo1 = context.Instructors
        .Include(i => i.CourseAssignments)
        .ToList();

    foreach (var instructor in instructorInfo1)
    {
        if (!instructor.CourseAssignments.Any())
        {
            Console.WriteLine($"Instructor: {instructor.Name}");
        }
    }

    var allInstructors = context.Instructors.ToList();

    foreach (var instructor in allInstructors)
    {
        context.Entry(instructor).Collection(i => i.CourseAssignments).Load();

        if (!instructor.CourseAssignments.Any())
        {
            Console.WriteLine($"Instructor without courses: {instructor.Name}");
        }
    }

}
