package com.example.spreadsheet2app;

import org.apache.http.HttpResponse;
import org.apache.http.client.HttpClient;
import org.apache.http.client.methods.HttpGet;
import org.apache.http.impl.client.DefaultHttpClient;
import org.apache.http.util.EntityUtils;
import org.json.JSONArray;
import org.json.JSONObject;

import android.app.Activity;
import android.content.Intent;
import android.os.AsyncTask;
import android.os.Bundle;
import android.text.Html;
import android.view.View;
import android.webkit.WebView;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemClickListener;
import android.widget.ArrayAdapter;
import android.widget.ListView;

/*
 * Hard-coded JSON data feed example
 * 
 * {"version":"1.0","encoding":"UTF-8","feed":{"xmlns":"http://www.w3.org/2005/Atom","xmlns$openSearch":"http://a9.com/-/spec/opensearchrss/1.0/","xmlns$gsx":"http://schemas.google.com/spreadsheets/2006/extended","id":{"$t":"https://spreadsheets.google.com/feeds/list/.../od6/public/values"},"updated":{"$t":"2015-07-12T00:00:00.000Z"},"category":[{"scheme":"http://schemas.google.com/spreadsheets/2006","term":"http://schemas.google.com/spreadsheets/2006#list"}],"title":{"type":"text","$t":"Sheet1"},"link":[{"rel":"alternate","type":"application/atom+xml","href":"https://docs.google.com/spreadsheets/d/.../pubhtml"},{"rel":"http://schemas.google.com/g/2005#feed","type":"application/atom+xml","href":"https://spreadsheets.google.com/feeds/list/.../od6/public/values"},{"rel":"http://schemas.google.com/g/2005#post","type":"application/atom+xml","href":"https://spreadsheets.google.com/feeds/list/.../od6/public/values"},{"rel":"self","type":"application/atom+xml","href":"https://spreadsheets.google.com/feeds/list/.../od6/public/values?alt\u003djson"}],"author":[{"name":{"$t":"spreadsheet2app"},"email":{"$t":"spreadsheet2app@email.com"}}],"openSearch$totalResults":{"$t":"2"},"openSearch$startIndex":{"$t":"1"},"entry":[{"id":{"$t":"https://spreadsheets.google.com/feeds/list/.../od6/public/values/cokwr"},"updated":{"$t":"2015-07-12T00:00:00.000Z"},"category":[{"scheme":"http://schemas.google.com/spreadsheets/2006","term":"http://schemas.google.com/spreadsheets/2006#list"}],"title":{"type":"text","$t":"1"},"content":{"type":"text","$t":"title: Item One T, description: Item One D, imagelink: http://drive.google.com/uc?export\u003dview\u0026id\u003d__ID__\u0026, lastupdated: 7/13/2015"},"link":[{"rel":"self","type":"application/atom+xml","href":"https://spreadsheets.google.com/feeds/list/.../od6/public/values/cokwr"}],"gsx$id":{"$t":"1"},"gsx$title":{"$t":"Item One T"},"gsx$description":{"$t":"Item One D"},"gsx$imagelink":{"$t":"http://drive.google.com/uc?export\u003dview\u0026id\u003d__ID__\u0026"},"gsx$lastupdated":{"$t":"7/13/2015"}},{"id":{"$t":"https://spreadsheets.google.com/feeds/list/.../od6/public/values/cpzh4"},"updated":{"$t":"2015-07-12T00:00:00.000Z"},"category":[{"scheme":"http://schemas.google.com/spreadsheets/2006","term":"http://schemas.google.com/spreadsheets/2006#list"}],"title":{"type":"text","$t":"2"},"content":{"type":"text","$t":"title: Item Two T, description: Item Two D, imagelink: http://drive.google.com/uc?export\u003dview\u0026id\u003d__ID__\u0026, lastupdated: 7/13/2015"},"link":[{"rel":"self","type":"application/atom+xml","href":"https://spreadsheets.google.com/feeds/list/.../od6/public/values/cpzh4"}],"gsx$id":{"$t":"2"},"gsx$title":{"$t":"Item Two T"},"gsx$description":{"$t":"Item Two D"},"gsx$imagelink":{"$t":"http://drive.google.com/uc?export\u003dview\u0026id\u003d__ID__\u0026"},"gsx$lastupdated":{"$t":"7/13/2015"}}]}}
 * 
 */

public class ItemsActivity extends Activity {
	
	ListView myListView;
	JSONArray myItems;
	
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_items);

// Customisation
		setInit();
	}
	
	void setInit()
	{
		myListView = (ListView) findViewById(R.id.id_items_listview);
		myListView.setOnItemClickListener(new OnItemClickListener(){

			@Override
			public void onItemClick(AdapterView<?> parent, View view,
					int position, long id) {
				// TODO Auto-generated method stub
				try
				{
					String s;
					Intent aIntent;
					
					s = myItems.getJSONObject(position).toString();
					
					aIntent = new Intent(ItemsActivity.this, ItemActivity.class);
					aIntent.putExtra(ItemActivity.FIELDKEY_ITEM, ""+s);
					startActivity(aIntent);
				}
				catch(Exception e)
				{
				}
			}
		});
		
		AsyncTaskSubmitStart aStart;
		aStart = new AsyncTaskSubmitStart();
		aStart.myUserAgent = ((WebView) findViewById(R.id.id_items_webview)).getSettings().getUserAgentString();
		aStart.myUserAgent = ""+(new WebView(ItemsActivity.this)).getSettings().getUserAgentString();
		aStart.execute();
	}
	
	private class AsyncTaskSubmitStart extends AsyncTask<Void, Void, Void> {
		
		public String myUserAgent;
		
		@Override
		protected Void doInBackground(Void... params) {
			// TODO Auto-generated method stub
			
			String s;
			try {
				String aLink;
				HttpClient aClient;
				HttpGet aGet;
				HttpResponse aResponse;
				JSONObject aJo;
				
				aLink = "https://goo.gl/...ID...";
				
				aClient = new DefaultHttpClient();
				aGet = new HttpGet(""+aLink);
				aGet.addHeader("User-Agent", ""+myUserAgent);
				aResponse = aClient.execute(aGet);
				s = EntityUtils.toString(aResponse.getEntity());
				s = Html.fromHtml(s).toString();
				
				aJo = new JSONObject(s);
				myItems = aJo.getJSONObject("feed").getJSONArray("entry");
				
				runOnUiThread(new Runnable() {
	  				  public void run() {
	  					  setItems(myItems);
	  				  }
				});
			}
			catch(Exception e)
			{
			}
			
			return null;
		}
		
	    @Override
	    protected void onPostExecute(Void result) {
	    }
	    
	    @Override
	    protected void onPreExecute() {
	    }
	
	    @Override
	    protected void onProgressUpdate(Void... values) {
	    }
	}
	
	void setItems(JSONArray aJsonArray)
	{
    	String[] aStrings;

    	try
    	{
        	aStrings = new String[aJsonArray.length()];
    		for (int i=0; i<aJsonArray.length(); i++)
    		{
    			aStrings[i] = new String(""+
    					String.format("%s",
    							aJsonArray.getJSONObject(i).getJSONObject("gsx$title").getString("$t")
    					)
    			);
    		}
    		
    		ArrayAdapter<String> aAdapter;
    		aAdapter = new ArrayAdapter<String>(this, android.R.layout.simple_list_item_1, android.R.id.text1, aStrings);
    		myListView.setAdapter(aAdapter);
    	}
    	catch(Exception e)
    	{
    		e.getMessage();
    	}
	}
}
