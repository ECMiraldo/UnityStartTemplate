using System;
using Newtonsoft.Json;


namespace Persistence 
{
    [Serializable]
    public class PersistentData
    {
        //anything you put in here will be saved to disk.
        //make sure object types(classes) or structs have the [Serializable] attribute
        //newtonsoft's Json documentation is right here: https://www.newtonsoft.com/json/help/html/Introduction.htm 
        [JsonProperty] private string hello = "Hello World";

    }

}


