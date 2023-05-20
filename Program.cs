using TutorialPractise.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<CustomMiddleware, CustomMiddleware>();

var app = builder.Build();

app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("Hello from Middleware 1\n");
    await next(context);
});

app.UseMyCustomMiddleware();
app.UseHelloCustomMiddleware();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Comment out the following lines:l
// app.UseHttpsRedirection();
// app.UseStaticFiles();

app.UseRouting();

app.MapGet("/", async context =>
{
    await context.Response.WriteAsync("Hello from Endpoint\n");
});

app.Run();
