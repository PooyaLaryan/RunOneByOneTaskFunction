var intList = Enumerable.Range(1, 20).Select(x => IntGenerator()).ToList();


////////// remove comment and test it 
/*Console.WriteLine("---------- All at once ---------");
var result = await Task.WhenAll(intList);   
foreach (var item in result)
{
    Console.WriteLine(item);
}
*/

Console.WriteLine("-------- one by one -------------");
while (intList.Any())
{
    var intGenerated = await Task.WhenAny(intList);
    intList.Remove(intGenerated);
    Console.WriteLine(await intGenerated);
}


/*
// .net 9
await foreach(var item in Task.WhenEach(intList))
{
    Console.WriteLine(await item);  
}
*/

async Task<int> IntGenerator()
{
    var intNum = new Random().Next(100, 1000);
    await Task.Delay(intNum);
    return intNum;
}