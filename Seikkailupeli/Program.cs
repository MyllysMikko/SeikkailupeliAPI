using Microsoft.EntityFrameworkCore;
using Seikkailupeli;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SeikkailupeliDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SeikkailupeliConnectionString"))
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/quest", async (SeikkailupeliDBContext db) => await db.Quests.ToListAsync());

app.MapGet("/quest/{id}", async (int id, SeikkailupeliDBContext db) =>
    await db.Quests.FindAsync(id)
        is Quest quest
            ? Results.Ok(quest)
            : Results.NotFound());

app.MapGet("/quest/completed", async (SeikkailupeliDBContext db) =>
    await db.Quests.Where(t => t.QuestIsCompleted).ToListAsync());

app.MapGet("/quest/inProgress", async (SeikkailupeliDBContext db) =>
    await db.Quests.Where(t => t.QuestIsStarted && !t.QuestIsCompleted).ToListAsync());

app.MapPut("quest/{id}", async (SeikkailupeliDBContext db, PutQuest quest, int id) =>
{
    var dbQuest = await db.Quests.FindAsync(id);

    if (dbQuest == null)
    {
        return Results.NotFound("Tehtävää ei löytynt!");
    }

    //dbQuest.Id = quest.Id;
    //dbQuest.QuestName = quest.QuestName;
    dbQuest.QuestIsStarted = quest.QuestIsStarted;
    dbQuest.QuestIsCompleted = quest.QuestIsCompleted;

    await db.SaveChangesAsync();

    return Results.Ok();
});

app.Run();