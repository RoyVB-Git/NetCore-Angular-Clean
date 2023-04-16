package com.museumslager.moderatorapp;

import com.getcapacitor.BridgeActivity;

import com.microsoft.appcenter.AppCenter;
import com.microsoft.appcenter.analytics.Analytics;
import com.microsoft.appcenter.crashes.Crashes;

public class MainActivity extends BridgeActivity {

      @Override
     public void onCreate(Bundle savedInstanceState) {
         AppCenter.start(getApplication(), "24792212-99d7-4f05-9101-aa98320682f4",
                  Analytics.class, Crashes.class);
         super.onCreate(savedInstanceState);
     }
}
