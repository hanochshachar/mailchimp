// See https://aka.ms/new-console-template for more information


using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using static System.Net.Mime.MediaTypeNames;
using System.Text.RegularExpressions;

/*static async Task Ping()
{
        string dc = "us11";
        string apikey = "";
        using (var httpClient = new HttpClient()) { 
    
        httpClient.BaseAddress = new Uri($"https://{dc}.api.mailchimp.com/3.0/");
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("hanoch", apikey);

        var response = await httpClient.GetAsync("");
        string jsonResponse = await response.Content.ReadAsStringAsync();

        Console.WriteLine(jsonResponse);
         } ;

        
    
}
await Ping();

static async Task CreateList()
{
    string dc = "us11";
    string apikey = "";

    string event_name = "Bash Developers Meetup";

    var footer_contact_info = new
    {
        company = "Mailchimp",
        address1 = "675 Ponce de Leon Ave NE",
        address2 = "Suite 5000",
        city = "Atlanta",
        state = "GA",
        zip = "30308",
        country = "US"
    };

    var campaign_defaults = new
    {
        from_name = "ha",
        from_email = "hanoch5010@gmail.com",
        subject = "קבוצה לאורי",
        language = "EN_US"
    };

    using (HttpClient client = new HttpClient())
    {
        string url = $"https://{dc}.api.mailchimp.com/3.0/lists";

        var data = new
        {
            name = event_name,
            contact = footer_contact_info,
            permission_reminder = "permission_reminder",
            email_type_option = true,
            campaign_defaults = campaign_defaults
        };

        var jsonData = new StringContent(
            Newtonsoft.Json.JsonConvert.SerializeObject(data),
            Encoding.UTF8,
            "application/json"
        );

        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("key", apikey);
        var response = await client.PostAsync(url, jsonData);
        var responseContent = await response.Content.ReadAsStringAsync();
        Console.WriteLine(responseContent);
        Console.WriteLine(url);
    }
}

await CreateList();
*/
static async Task getLists()
{
    string dc = "us11";
    string apikey = "";

    using (HttpClient client = new HttpClient())
    {
        string url = $"https://{dc}.api.mailchimp.com/3.0/lists";

        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("hanoch", apikey);

        var response = await client.GetAsync(url);
        string jsonResponse = await response.Content.ReadAsStringAsync();

        string pattern = "\"id\":";

        // Use the Matches method to find all occurrences of the word
        MatchCollection matches = Regex.Matches(jsonResponse, pattern);

        // Output the number of occurrences
        int count = matches.Count;
        //Console.WriteLine("The word '{0}' appears {1} times in the text.", pattern, count);
        //Console.WriteLine(jsonResponse);
       

        dynamic data = JsonConvert.DeserializeObject(jsonResponse);

        for (int i = 0; i < data.lists.Count; i++)
        {
            string id = data.lists[i].id;
            string name = data.lists[i].name;

            Console.WriteLine($"List Index: {i}");
            Console.WriteLine($"List ID: {id}");
            Console.WriteLine($"List Name: {name}");
        }
    }
}

await getLists();
/*
static async Task addContactToList()
{
    string dc = "us11";
    string apikey = "";

    string list_id = "4ac29a83ab";
    string user_email = "jj@kk.com";
    string user_fname = "Prudence";
    string user_lname = "McVankab";

    using(HttpClient client = new HttpClient())
    {
        string url = $"https://{dc}.api.mailchimp.com/3.0/lists/{list_id}/members";

        var data = new
        {
            email_address = $"{user_email}",
            status = "subscribed",
            merge_fields = new
            {
                FNAME = $"{user_fname}",
                LNAME = $"{user_lname}"
            }
         };

        var jsonData = new StringContent(
            Newtonsoft.Json.JsonConvert.SerializeObject(data),
            Encoding.UTF8,
            "application/json"
        );


        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("key", apikey);
        var response = await client.PostAsync(url, jsonData);
        var responseContent = await response.Content.ReadAsStringAsync();
        Console.WriteLine(responseContent);
    }
}

await addContactToList(); 

static async Task getCampaigns()
{
    string dc = "us11";
    string apikey = "";

    using(HttpClient client = new HttpClient())
    {
        string uri = $"https://{dc}.api.mailchimp.com/3.0/campaigns";

        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("key", apikey);

        var response = await client.GetAsync(uri);

        var responseContent = await response.Content.ReadAsStringAsync();
        Console.WriteLine(responseContent);
        Console.WriteLine(uri);

        string pattern = "\"id\":";

        // Use the Matches method to find all occurrences of the word
        MatchCollection matches = Regex.Matches(responseContent, pattern);

        // Output the number of occurrences
        int count = matches.Count;
        Console.WriteLine("The word '{0}' appears {1} times in the text.", pattern, count);

    }
}

await getCampaigns();*/


