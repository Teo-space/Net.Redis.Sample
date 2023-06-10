using Microsoft.Extensions.Caching.Distributed;
using StackExchange.Redis;

///Run Redis
//docker run --name some-redis -p 6379:6379 -d redis:latest --requirepass zxcv1234


///via ConnectionMultiplexer
{
    using ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost:6379, password=zxcv1234");
    Console.WriteLine($"ConnectionMultiplexer.IsConnected {redis.IsConnected}");

    IDatabase db = redis.GetDatabase();
    //IDatabase db = redis.GetDatabase(databaseNumber, asyncState);

    if (db.StringSet("mykey", "Vaaaaaalue"))
    {
        string value1 = db.StringGet("mykey");
        Console.WriteLine($"ConnectionMultiplexer.Value {value1}");
    }
}




///via Dependency Injection
{
    ServiceCollection services = new ServiceCollection();
    services.AddStackExchangeRedisCache(options =>
    {
        options.Configuration = "localhost:6379, password=zxcv1234";
        options.InstanceName = "SampleInstance";
    });
    services.AddDistributedMemoryCache(options =>
    {

    });

    var serviceProvider = services.BuildServiceProvider();

    var cache = serviceProvider.GetRequiredService<IDistributedCache>();

    cache.Set("Key", new SomeConfig("Value", 1000));


    var value = cache.Get<SomeConfig>("Key");
    Console.WriteLine(value);
}




///Redis pub-sub
{
    using ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost:6379, password=zxcv1234");
    Console.WriteLine($"ConnectionMultiplexer.IsConnected {redis.IsConnected}");

    ISubscriber sub = redis.GetSubscriber();
    sub.Subscribe("messages", (channel, message) =>
    {
        Console.WriteLine($"[Subscriber1] {message.ToString() ?? ""}");
    });


    // Synchronous handler
    sub.Subscribe("messages").OnMessage(channelMessage =>
    {
        string message = channelMessage.Message.ToString() ?? "";
        Console.WriteLine($"[Subscriber2] {message}");
    });

    // Asynchronous handler
    sub.Subscribe("messages").OnMessage(async channelMessage =>
    {
        await Task.Delay(1);
        string message = channelMessage.Message.ToString() ?? "";
        Console.WriteLine($"[Subscriber3] {message}");
    });


    for(int i = 0; i < 5; i++)
    {
        sub.Publish("messages", $"Message{i}");
    }
    
    

    Console.ReadKey();
}












record SomeConfig(string p1, int p2);


