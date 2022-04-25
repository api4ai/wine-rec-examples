﻿using System;
using System.Net.Http;
using System.Text.Json.Nodes;

using MimeTypes;
using RestSharp;


/*
 * Use "demo" mode just to try api4ai for free. Free demo is rate limited.
 * For more details visit:
 *   https://api4.ai
 *
 * Use 'rapidapi' if you want to try api4ai via RapidAPI marketplace.
 * For more details visit:
 *   https://rapidapi.com/api4ai-api4ai-default/api/wine-recognition2/details
 */

const String MODE = "demo";


/*
 * Your RapidAPI key. Fill this variable with the proper value if you want
 * to try api4ai via RapidAPI marketplace.
 */
const String RAPIDAPI_KEY = "";

String url;
Dictionary<String, String> headers = new Dictionary<String, String>();

switch (MODE) {
    case "demo":
        url = "https://demo.api4ai.cloud/wine-rec/v1/results";
        headers.Add("A4A-CLIENT-APP-ID", "sample");
        break;
    case "rapidapi":
        url = "https://wine-recognition2.p.rapidapi.com/v1/results";
        headers.Add("X-RapidAPI-Key", RAPIDAPI_KEY);
        break;
    default:
        Console.WriteLine($"[e] Unsupported mode: {MODE}");
        return 1;
}

// Prepare request.
String image = args.Length > 0 ? args[0] : "https://storage.googleapis.com/api4ai-static/samples/wine-3.jpg";
var client = new RestClient(new RestClientOptions(url) { ThrowOnAnyError = true });
var request = new RestRequest();
if (image.Contains("://")) {
    request.AddParameter("url", image);
} else {
    request.AddFile("image", image, MimeTypeMap.GetMimeType(Path.GetExtension(image)));
}

// Perform request.
var jsonResponse = (await client.ExecutePostAsync(request)).Content!;

// Print raw response.
Console.WriteLine($"[i] Raw response:\n{jsonResponse}\n");

// Parse response and print recognized brands with probabilities.
JsonNode docRoot = JsonNode.Parse(jsonResponse)!.Root;
JsonObject probs = docRoot["results"]![0]!["entities"]![0]!["classes"]!.AsObject();
Console.WriteLine($"[i] Probabilities:\n{probs}");

return 0;
