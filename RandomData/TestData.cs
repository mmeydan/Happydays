namespace RandomData
{
    public static class TestData
    {
        public static string RandomFirstName { get { return Faker.Name.First().ToUpper(); } }
        public static string RandomSurname { get { return Faker.Name.Last().ToUpper(); } }
        public static string RandomStreet { get { return Faker.Address.StreetAddress().ToUpper(); } }
        public static string RandomEmail { get { return Faker.Internet.Email().ToUpper(); } }
        public static string RandomPostCode { get { return Faker.Address.UkPostCode().ToUpper(); } }
    }
}
