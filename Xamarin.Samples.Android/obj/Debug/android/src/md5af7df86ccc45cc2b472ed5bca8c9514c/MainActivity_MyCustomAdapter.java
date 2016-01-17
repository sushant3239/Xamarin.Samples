package md5af7df86ccc45cc2b472ed5bca8c9514c;


public class MainActivity_MyCustomAdapter
	extends md53471cbf751f08dad2f5f63288aefa6f2.MvxAdapter
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_getView:(ILandroid/view/View;Landroid/view/ViewGroup;)Landroid/view/View;:GetGetView_ILandroid_view_View_Landroid_view_ViewGroup_Handler\n" +
			"n_getCount:()I:GetGetCountHandler\n" +
			"";
		mono.android.Runtime.register ("Xamarin.Samples.Android.MainActivity+MyCustomAdapter, Xamarin.Samples.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", MainActivity_MyCustomAdapter.class, __md_methods);
	}


	public MainActivity_MyCustomAdapter () throws java.lang.Throwable
	{
		super ();
		if (getClass () == MainActivity_MyCustomAdapter.class)
			mono.android.TypeManager.Activate ("Xamarin.Samples.Android.MainActivity+MyCustomAdapter, Xamarin.Samples.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	public MainActivity_MyCustomAdapter (android.content.Context p0) throws java.lang.Throwable
	{
		super ();
		if (getClass () == MainActivity_MyCustomAdapter.class)
			mono.android.TypeManager.Activate ("Xamarin.Samples.Android.MainActivity+MyCustomAdapter, Xamarin.Samples.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
	}


	public android.view.View getView (int p0, android.view.View p1, android.view.ViewGroup p2)
	{
		return n_getView (p0, p1, p2);
	}

	private native android.view.View n_getView (int p0, android.view.View p1, android.view.ViewGroup p2);


	public int getCount ()
	{
		return n_getCount ();
	}

	private native int n_getCount ();

	java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
