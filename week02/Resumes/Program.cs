using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._company = "Google";
        job1._jobtitle = "Software Engineer";
        job1._startyear = 2018;
        job1._endyear = 2022;

        Job job2 = new Job();
         job2._company = "Microsoft";
        job2._jobtitle = "Software Engineer";
        job2._startyear = 2015;
        job2._endyear = 2020;

       Resume myResume = new Resume();
        myResume._name = "John Doe";
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);
        myResume.DisplayResumeDetails();
        
    }
}