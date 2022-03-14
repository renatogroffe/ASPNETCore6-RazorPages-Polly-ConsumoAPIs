using SiteConsumoAPIContagem.Clients;
using SiteConsumoAPIContagem.Resilience;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

builder.Services.AddHttpClient<APIContagemClient>();
    .AddPolicyHandler(RetryExtensions.CreatePolicy(
        Convert.ToInt32(builder.Configuration["NumberOfRetries"])
    ));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();