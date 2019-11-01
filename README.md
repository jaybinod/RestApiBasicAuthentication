# RestApiBasicAuthentication

This API is complete presentaiton of Data handling through Web API with Audit Log like how many time user hit and view complete data created by respective user/or view perticular record/added new record/changes in record / deleted record with Basic Authentication. even user can check what changes has done.

There are 2 project added in single solution 
1) Web API
2) Client side project

Web APi is API project in which controller protected through Basic authentication. If any user from client side want to do any activity on data file first they need to login which will verify and if it's sucessfully authenticated then API will allow user to show data file or allow to do changes in any record. In Basic Authenticaiton: The client sends request, with the client credentials in the Authorization header. The credentials are formatted as the string "name:password", base64-encoded.

Client side project is complete presentation of how you can GET/POST/PUT/PATCH and DELETE item through web api

Hope this helps.

Thanks
