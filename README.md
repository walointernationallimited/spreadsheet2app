# spreadsheet2app
spreadsheet2app is a project that includes the steps in using Google Spreadsheet to feed its data in JSON format to applications such as smartphone (Android, iOS, ...) apps.

<br/>The document was drafted on 12 July 2015.
<br/>It is used as reference for
<br/>- <a href="#spreadsheet2app_1">Publishing JSON feed from Google spreadsheet</a>
<br/>- <a href="#spreadsheet2app_2">Publishing web image from Google Drive</a>
<br/>- <a href="#spreadsheet2app_3">Publishing Google URL Shortener with Google Analytics</a>

<br/>

<a name="spreadsheet2app_1" />
<pre>
<h1>Publishing JSON feed from Google spreadsheet</h1>

- Login to Google Drive
http://drive.google.com/

- Create Folder "spreadsheet2app"
Right mouse button click on "My Drive"
Select "New folder..."
Label it as "spreadsheet2app"

- Create Spreadsheet "spreadsheet2app_data"
Double click on folder named "spreadsheet2app"
Right mouse button click at centre > New file... > Google Sheets
Click on "Untitled spreadsheet" and rename it as "spreadsheet2app_data"

- Create data for Spreadsheet "spreadsheet2app_data"
- In CSV format
id,title,description,imagelink,lastinserted
1,Item One T,Item One D,http://drive.google.com/uc?export=view&id=__ID__&,7/13/2015
2,Item Two T,Item Two D,http://drive.google.com/uc?export=view&id=__ID__&,7/13/2015

- Publish Spreadsheet "spreadsheet2app_data" to the web
Click "File" tab, then select "Publish to the web..."
Click "Publish"
Copy spreadsheet key section __...__ in the link of the format: https://docs.google.com/spreadsheets/d/__...__/pub?output=html

- Get the published feed for Spreadsheet "spreadsheet2app_data"
Logout from Google Drive
Browse the link to the published feed by pasting the copied spreadsheet key section __...__ into the link:
https://spreadsheets.google.com/feeds/list/__...__/od6/public/values?alt=json&
</pre>

<a name="spreadsheet2app_2" />
<pre>
<h1>Publishing web image from Google Drive</h1>

- Login to Google Drive
http://drive.google.com/

- Create Folder "My Drive/spreadsheet2app/items"
Right mouse button click on "spreadsheet2app"
Select "New folder..."
Label it as "items"

- Prepare image "item1.png"
Double click on folder named "items"
Right mouse button click at centre > Upload files... > Select "item1.png"

- Share image "item1.png"
Right mouse button click on "item1.png"
Select "Share..."
In the "Share with others" box, click on "Advanced"
In the "Sharing settings" box, click on "Change" in the row titled "Private - Only you can access"
In the "Link sharing" box, select option "On - Anyone with the link", then hit Save
In the "Sharing settings" box, copy the ID section __ID__ in the link
https://drive.google.com/file/d/__ID__/view?usp=sharing

- Include copied __ID__ to the image link in the Spreadsheet "spreadsheet2app_data"
- In CSV format
id,title,description,imagelink,lastinserted
1,Item One T,Item One D,http://drive.google.com/uc?export=view&id=__ID__&,7/13/2015
2,Item Two T,Item Two D,http://drive.google.com/uc?export=view&id=__ID__&,7/13/2015

- Test the updated image link from the published data feed
Logout from Google Drive
Browse the link for the updated image link: view-source:https://docs.google.com/spreadsheets/d/.../pub?output=csv
Extract the updated image link formatted: http://drive.google.com/uc?export=view&id=__ID__&
Browse the image link to see if it can be accessed without sign-in: http://drive.google.com/uc?export=view&id=__ID__&
Check to see if the image link has also been updated in the JSON data feed: https://spreadsheets.google.com/feeds/list/.../od6/public/values?alt=json&

</pre>

<a name="spreadsheet2app_3" />
<pre>
<h1>Publishing Google URL Shortener with Google Analytics</h1>

- Go to Google URL Shortener
http://goo.gl/

- Verify with Captcha test
Check "I'm not a robot"
Mark those images matching to the given keyword

- Fill in the form with the data feed link
At field label "Paste your long URL here:": https://spreadsheets.google.com/feeds/list/.../od6/public/values?alt=json&
Hit button "Shorten URL"

- Copy the shortened URL and its analytics link
Shortened URL format: https://goo.gl/...ID...
Its analytics link format: https://goo.gl/#analytics/goo.gl/...ID.../all_time

</pre>

<br/>
