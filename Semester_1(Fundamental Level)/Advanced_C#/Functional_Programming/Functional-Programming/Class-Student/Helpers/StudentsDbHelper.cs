namespace Functional_Programming.Helpers
{
    using System.Collections.Generic;
    using Data;
    using Models;

    public static class StudentsDbHelper
    {
        public static void FillStudentDb(StudentsDB db)
        {
            db.AddStudent(new Student("Pensho", "Penchev", 35, 35251455, "025454564", "Penchev@Pencho.pc",
                new List<int>() {6, 4, 5, 6, 5}, 1));
            db.AddStudent(new Student("Vanko", "Vankov", 22, 22241556, "045465456564", "Vankov@Vanko.vk",
               new List<int>() { 4, 4, 5, 6, 6 }, 2));
            db.AddStudent(new Student("Minka", "Minkova", 27, 95541555, "+35924454564", "Minkova@Minka.mk",
               new List<int>() { 6, 2, 5, 4, 5 }, 1));
            db.AddStudent(new Student("Penka", "Penkova", 29, 29251455, "044577644565", "Penkova@Penka.pk",
               new List<int>() { 2, 3, 5, 2, 5 }, 2));
            db.AddStudent(new Student("Shmatko", "Shmatkov", 38, 38991565, "088545456654", "Shmatkov@Shmatko.sh",
               new List<int>() { 5, 4, 5, 5, 5 }, 3));
            db.AddStudent(new Student("Stancho", "Stanchev", 44, 44251555, "04480454564", "Stanchev@Stancho.st",
               new List<int>() { 6, 3, 6, 6, 6 }, 1));
            db.AddStudent(new Student("Anka", "Ankova", 19, 19251519, "08854545444", "Ankova@abv.bg",
               new List<int>() { 6, 3, 6 }, 1));
        }
    }
}