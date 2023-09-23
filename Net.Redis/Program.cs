using Net.Redis;

///Run Redis
//docker run --name some-redis -p 6379:6379 -d redis:latest --requirepass zxcv1234


//Tests.TestFill(10000);

//Tests.TestViaConnectionMultiplexer();
//Tests.TestViaConnectionMultiplexer();
//Tests.TestViaConnectionMultiplexer();
//Tests.TestViaConnectionMultiplexer();



/*
//docker run --name some-redis -p 6379:6379 -d redis:latest --requirepass zxcv1234
Tests.TestFill(10000);


[[2023.09.23 10:44.25.407]]Fill Cache(-0,08)
[[2023.09.23 10:44.31.104]]Done(5691,49)
ConnectionMultiplexer.IsConnected True
[[2023.09.23 10:44.31.118]]StringSet(14,13)
[[2023.09.23 10:44.31.119]]Ok(0,88)
[[2023.09.23 10:44.31.122]]StringGet(2,53)
[[2023.09.23 10:44.31.122]]Value Vaaaaaalue(0,34)
ConnectionMultiplexer.IsConnected True
[[2023.09.23 10:44.31.128]]StringSet(5,31)
[[2023.09.23 10:44.31.129]]Ok(1,05)
[[2023.09.23 10:44.31.130]]StringGet(1,14)
[[2023.09.23 10:44.31.130]]Value Vaaaaaalue(0,34)
ConnectionMultiplexer.IsConnected True
[[2023.09.23 10:44.31.138]]StringSet(7,44)
[[2023.09.23 10:44.31.139]]Ok(0,93)
[[2023.09.23 10:44.31.140]]StringGet(0,9)
[[2023.09.23 10:44.31.140]]Value Vaaaaaalue(0,35)
ConnectionMultiplexer.IsConnected True
[[2023.09.23 10:44.31.149]]StringSet(9,32)
[[2023.09.23 10:44.31.150]]Ok(0,92)
[[2023.09.23 10:44.31.151]]StringGet(0,88)
[[2023.09.23 10:44.31.151]]Value Vaaaaaalue(0,33)


1 Thread
docker pull eqalpha/keydb
docker run --name some-keydb -p 6379:6379 -d eqalpha/keydb --requirepass zxcv1234
Tests.TestFill(10000);

[[2023.09.23 10:47.19.591]]Fill Cache(-0,13)
[[2023.09.23 10:47.25.477]]Done(5879,51)
ConnectionMultiplexer.IsConnected True
[[2023.09.23 10:47.25.491]]StringSet(13,26)
[[2023.09.23 10:47.25.492]]Ok(1,05)
[[2023.09.23 10:47.25.494]]StringGet(2,53)
[[2023.09.23 10:47.25.495]]Value Vaaaaaalue(0,34)
ConnectionMultiplexer.IsConnected True
[[2023.09.23 10:47.25.505]]StringSet(10,22)
[[2023.09.23 10:47.25.506]]Ok(1)
[[2023.09.23 10:47.25.507]]StringGet(1,04)
[[2023.09.23 10:47.25.507]]Value Vaaaaaalue(0,34)
ConnectionMultiplexer.IsConnected True
[[2023.09.23 10:47.25.513]]StringSet(5,11)
[[2023.09.23 10:47.25.514]]Ok(0,97)
[[2023.09.23 10:47.25.515]]StringGet(1,08)
[[2023.09.23 10:47.25.515]]Value Vaaaaaalue(0,35)
ConnectionMultiplexer.IsConnected True
[[2023.09.23 10:47.25.523]]StringSet(7,57)
[[2023.09.23 10:47.25.524]]Ok(0,94)
[[2023.09.23 10:47.25.525]]StringGet(0,96)
[[2023.09.23 10:47.25.525]]Value Vaaaaaalue(0,33)



4 Thread
docker run --name some-keydb -p 6379:6379 -d eqalpha/keydb --requirepass zxcv1234 --server-threads 4
Tests.TestFill(10000);









*/


