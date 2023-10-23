namespace lab19.Dto
{
    public static class StudentDtoExtension
    {
        public static string GetNume(this NewStudentDto studentTransfer) => 
            studentTransfer.Nume;

        public static string GetPrenume(this NewStudentDto studentTransfer) =>
            studentTransfer.Prenume;
        public static string GetOras(this NewStudentDto studentTransfer) =>
            studentTransfer.Oras;
        public static string GetStrada(this NewStudentDto studentTransfer) =>
            studentTransfer.Strada;

    }
}
