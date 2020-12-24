namespace quickstart
{
    internal class HealthCheckOptions : Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions
    {
        public object ResponseWriter { get; set; }
    }
}