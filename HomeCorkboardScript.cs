using System;
using Boo.Lang.Runtime;
using UnityEngine;
using UnityScript.Lang;

// Token: 0x020000AE RID: 174
[Serializable]
public class HomeCorkboardScript : MonoBehaviour
{
	// Token: 0x060003CF RID: 975 RVA: 0x0004C2F8 File Offset: 0x0004A4F8
	public virtual void Update()
	{
		if (!this.HomeYandere.CanMove)
		{
			if (!this.Loaded)
			{
				this.StartCoroutine_Auto(this.PhotoGallery.GetPhotos());
				this.Loaded = true;
			}
			if (!this.PhotoGallery.Adjusting && !this.PhotoGallery.Viewing && !this.PhotoGallery.LoadingScreen.active && Input.GetButtonDown("B"))
			{
				this.HomeCamera.Destination = this.HomeCamera.Destinations[0];
				this.HomeCamera.Target = this.HomeCamera.Targets[0];
				this.HomeCamera.CorkboardLabel.active = true;
				this.PhotoGallery.enabled = false;
				this.HomeYandere.CanMove = true;
				this.HomeYandere.active = true;
				this.HomeWindow.Show = false;
				this.enabled = false;
				this.Loaded = false;
				if (RuntimeServices.EqualityOperator(UnityRuntimeServices.GetProperty(this.HomeCamera, "DisablePost"), false))
				{
				}
			}
		}
	}

	// Token: 0x060003D0 RID: 976 RVA: 0x0004C41C File Offset: 0x0004A61C
	public virtual void Main()
	{
	}

	// Token: 0x0400097C RID: 2428
	public InputManagerScript InputManager;

	// Token: 0x0400097D RID: 2429
	public PhotoGalleryScript PhotoGallery;

	// Token: 0x0400097E RID: 2430
	public HomeYandereScript HomeYandere;

	// Token: 0x0400097F RID: 2431
	public HomeCameraScript HomeCamera;

	// Token: 0x04000980 RID: 2432
	public HomeWindowScript HomeWindow;

	// Token: 0x04000981 RID: 2433
	public bool Loaded;
}
