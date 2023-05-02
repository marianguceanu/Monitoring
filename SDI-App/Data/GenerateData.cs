using System;

namespace SDI_App.Data
{
    public class GenerateData
    {
        public static async void PopulatePerson()
        {
            string baseUrl = "api.name-fake.com/english-united-states/female/";
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(baseUrl))
                {
                    using (HttpContent content = res.Content)
                    {
                        var data = await content.ReadAsStringAsync();
                        Console.WriteLine(data);
                    }
                }
            }

        }
    }
}