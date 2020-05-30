using System;
using System.Collections.Generic;

namespace CollegePortalApplication.Model
{
    public static class AdmOptionData
    {
        public static IList<AdmOption> Options { get; private set; }
        static AdmOptionData()
        {
            Options = new List<AdmOption>();

            Options.Add(new AdmOption
            {
                Id = "AO01",
                OptionName="Activities"
            });
            Options.Add(new AdmOption
            {
                Id = "AO02",
                OptionName = "Attendance"
            });
            Options.Add(new AdmOption
            {
                Id = "AO03",
                OptionName = "Courses"
            });
            Options.Add(new AdmOption
            {
                Id = "AO04",
                OptionName = "Credit"
            });
            Options.Add(new AdmOption
            {
                Id = "AO05",
                OptionName = "Module"
            });
            Options.Add(new AdmOption
            {
                Id = "AO06",
                OptionName = "Payments"
            });
            Options.Add(new AdmOption
            {
                Id = "AO07",
                OptionName = "Staff"
            });
            Options.Add(new AdmOption
            {
                Id = "AO08",
                OptionName = "Student"
            });
            Options.Add(new AdmOption
            {
                Id = "AO09",
                OptionName = "Student Overview"
            });
            Options.Add(new AdmOption
            {
                Id = "AO10",
                OptionName = "Users Account Type"
            });
        }
    }
}
