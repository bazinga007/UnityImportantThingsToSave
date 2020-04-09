# UnityImportantThingsToSave
UnityImportantThingsToSave

######################################################################################
Sending Web Request with Content to google Speech API
#########################################################################################
         UnityWebRequest webRequest = new UnityWebRequest(<URL>, "POST");
         byte[] encodedPayload = new System.Text.UTF8Encoding().GetBytes(<JSON PAYLOAD STRING>);
         webRequest.uploadHandler = (UploadHandler) new UploadHandlerRaw(encodedPayload);
         webRequest.downloadHandler = (DownloadHandler) new DownloadHandlerBuffer();
         webRequest.SetRequestHeader("Content-Type", "application/json");
         webRequest.SetRequestHeader("cache-control", "no-cache");
         
         UnityWebRequestAsyncOperation requestHandel = webRequest.SendWebRequest();
         requestHandel.completed += delegate(AsyncOperation pOperation) {
             Debug.Log(webRequest.responseCode);
             Debug.Log(webRequest.downloadHandler.text);
         };
#########################################################################################
