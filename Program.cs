using efcore_nullable_guid_string;

{
    // Setup database structure
    using var contextSetup = new MyDbContext();
    contextSetup.Database.EnsureDeleted();
    contextSetup.Database.EnsureCreated();
}

{
    // Add existing entities
    using var context = new MyDbContext();
    context.MyEntities.Add(new() { Id = new Guid("6d872515-ee58-4e1a-9780-86c0e93ddbec"), Property = new Guid("bea0136e-1ac3-437a-85b2-5b60d7f4d4ae") });
    context.MyEntities.Add(new() { Id = new Guid("d7de0a43-29c3-4986-8846-ef8d60fc11b6"), Property = null });
    context.SaveChanges();
}

{
    using var context = new MyDbContext();
    var query =
        from e in context.MyEntities
        select new MyModel() { Id = e.Id, Property = Guid.Empty };

    foreach (var m in query.ToList())
    {
        Console.WriteLine("{0} {1}", m.Id, m.Property);
    }
}
