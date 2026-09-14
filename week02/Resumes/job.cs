public class Job
{
    public string _company;
    public string _jobtitle;
    public int _startyear;
    public int _endyear;

    public void DisplayJobDetails()
    {
        Console.WriteLine($"Company: {_company}, Job Title: {_jobtitle}, Years: {_startyear} - {_endyear}");
    }
}