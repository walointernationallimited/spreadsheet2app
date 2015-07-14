package com.example.spreadsheet2app;

import java.io.InputStream;

import org.apache.http.HttpResponse;
import org.apache.http.client.HttpClient;
import org.apache.http.client.methods.HttpGet;
import org.apache.http.impl.client.DefaultHttpClient;
import org.json.JSONObject;

import android.app.Activity;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.graphics.Matrix;
import android.graphics.RectF;
import android.os.AsyncTask;
import android.os.Bundle;
import android.widget.ImageView;
import android.widget.TextView;

public class ItemActivity extends Activity {
	
	JSONObject myItem;
	public static String FIELDKEY_ITEM = "fieldkey_item";
	
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_item);

// Customisation
		setInit();
	}
	
	void setInit()
	{
		TextView aTextView;
		String s;
		ImageView aImageView;
		
		try
		{
			myItem = new JSONObject(""+this.getIntent().getStringExtra(FIELDKEY_ITEM));
			
			s = String.format("%s", myItem.getJSONObject("gsx$title").getString("$t"));
			aTextView = (TextView) findViewById(R.id.id_item_title);
			aTextView.setText(""+s);
			
			s = String.format("%s", myItem.getJSONObject("gsx$lastupdated").getString("$t"));
			aTextView = (TextView) findViewById(R.id.id_item_date);
			aTextView.setText(""+s);
			
			s = String.format("%s", myItem.getJSONObject("gsx$description").getString("$t"));
			aTextView = (TextView) findViewById(R.id.id_item_description);
			aTextView.setText(""+s);
			
			s = String.format("%s", myItem.getJSONObject("gsx$imagelink").getString("$t"));
			aImageView = (ImageView) findViewById(R.id.id_item_imageview);
			(new AsyncTaskDownloadImageStart(aImageView)).execute(""+myItem.getJSONObject("gsx$imagelink").getString("$t"));
		}
		catch(Exception e)
		{
		}
	}

// Image size under 1MB
	private class AsyncTaskDownloadImageStart extends AsyncTask<String, Void, Bitmap> {
	    ImageView myImageView;

	    public AsyncTaskDownloadImageStart(ImageView bmImage) {
	        this.myImageView = bmImage;
	    }

	    protected Bitmap doInBackground(String... urls) {
	        String aUrl = urls[0];
	        Bitmap mIcon11 = null;
	        Bitmap b;
	        
	        try {
	        	HttpClient aClient;
	        	HttpGet aGet;
	        	HttpResponse aResponse;
	        	InputStream aInputStream;
	        	Matrix aMatrix;
	        	
				aClient = new DefaultHttpClient();
				aGet = new HttpGet(""+urls[0]);
				aResponse = aClient.execute(aGet);

	            aInputStream = new java.net.URL(aUrl).openStream();
	            aInputStream = aResponse.getEntity().getContent();
	            mIcon11 = BitmapFactory.decodeStream(aInputStream);

	            b = mIcon11;
	            aMatrix = new Matrix();
	            aMatrix.setRectToRect(new RectF(0, 0, b.getWidth(), b.getHeight()), new RectF(0, 0, getWindow().getWindowManager().getDefaultDisplay().getWidth(), getWindow().getWindowManager().getDefaultDisplay().getHeight()), Matrix.ScaleToFit.CENTER);
	            mIcon11 = Bitmap.createBitmap(b, 0, 0, b.getWidth(), b.getHeight(), aMatrix, true);
	            
	        } catch (Exception e) {
	            e.printStackTrace();
	        }
	        return mIcon11;
	    }

	    protected void onPostExecute(Bitmap result) {
	        myImageView.setImageBitmap(result);
	    }
	}
}
