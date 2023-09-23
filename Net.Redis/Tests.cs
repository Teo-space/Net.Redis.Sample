using Microsoft.Extensions.Caching.Distributed;
using StackExchange.Redis;

namespace Net.Redis;

internal class Tests
{

    public static void TestFill(int Count)
    {
        using ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost:6379, password=zxcv1234");
        Console.WriteLine($"ConnectionMultiplexer.IsConnected {redis.IsConnected}");

        IDatabase db = redis.GetDatabase();
        //IDatabase db = redis.GetDatabase(databaseNumber, asyncState);
        print("Fill Cache");
        //Fill Cache
        for (int i = 0; i < Count; i++)
        {
            db.StringSet(Guid.NewGuid().ToString(), "Vaaaaaalue");
        }
        print("Done");
    }



    public static void TestViaConnectionMultiplexer()
    {
        using ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost:6379, password=zxcv1234");
        Console.WriteLine($"ConnectionMultiplexer.IsConnected {redis.IsConnected}");

        IDatabase db = redis.GetDatabase();
        //IDatabase db = redis.GetDatabase(databaseNumber, asyncState);

        print("StringSet");
        if (db.StringSet("mykey", "Vaaaaaalue"))
        {
            print("Ok");
            string value = db.StringGet("mykey");
            print("StringGet");
            print($"Value {value}");
        }

    }


    public static void TestDependencyInjection()
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

        print("StringSet");
        cache.Set("Key", new SomeConfig("Value", 1000));
        print("Ok");
        print("StringGet");
        var value = cache.Get<SomeConfig>("Key");
        print($"Value {value}");
    }





    public static void TestPubSub()
    {
        using ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost:6379, password=zxcv1234");
        print($"ConnectionMultiplexer.IsConnected {redis.IsConnected}");

        ISubscriber sub = redis.GetSubscriber();
        sub.Subscribe("messages", (channel, message) =>
        {
            print($"[Subscriber1] {message.ToString() ?? ""}");
        });


        // Synchronous handler
        sub.Subscribe("messages").OnMessage(channelMessage =>
        {
            string message = channelMessage.Message.ToString() ?? "";
            print($"[Subscriber2] {message}");
        });

        // Asynchronous handler
        sub.Subscribe("messages").OnMessage(async channelMessage =>
        {
            await Task.Delay(1);
            string message = channelMessage.Message.ToString() ?? "";
            print($"[Subscriber3] {message}");
        });


        for (int i = 0; i < 5; i++)
        {
            sub.Publish("messages", $"Message{i}");
        }



        Console.ReadKey();
    }












}
