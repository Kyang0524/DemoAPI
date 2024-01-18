using System;
namespace Rhino.Compute
{
    public static class AuthToken
    {
        public static string Get ()
        {
            // Set RHINO_COMPUTE_TOKEN environment variable or provide your token here

            String tokenFromEnv = System.Environment.GetEnvironmentVariable("RHINO_COMPUTE_TOKEN");
            if (!String.IsNullOrEmpty (tokenFromEnv))
            {
                return tokenFromEnv;
            } else
            {
                return "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJwIjoiUEtDUyM3IiwiYyI6IkFFU18yNTZfQ0JDIiwiYjY0aXYiOiIzeEgxSllFeGJva2xUUEFRbjIyRm9RPT0iLCJiNjRjdCI6IllqMzhqYUpVaXBOVTdEMlpOUlo3ZHo5QWJFWlUxSnlSRE54MXRWcHhGOVVYMlkzSjFadzVmYlVSZVBNZUpZUXNGSzZDeWt4aHRSQTArOGZuSHJ6b1V5dEtaNytrSG9BWmx3KzNsVkExWXZhd0h1Vkc2V2ZPNllrN3dvRXlWeWZrUUJJeW4rdkxjT1R2V2Y0K2ljRStpTnJ6NERPalB4Nmw2K3FJQWQyZ1ZYNStYV2tiQ0tHVkZ0NFZERGM5b2lUZ3A1UzdhaDVuRmt0NTFJZ25MWVRXenc9PSIsImlhdCI6MTY5ODk5NDk2Mn0.dyw7q1dzmo-H98KTu0NtnR5BqzQ6_YaUdWinFIg0Jrk";
            }

        }
    }
}
