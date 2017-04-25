using System;
using UnityEngine;

// Token: 0x0200005B RID: 91
[Serializable]
public class CameraEffectsScript : MonoBehaviour
{
	// Token: 0x06000248 RID: 584 RVA: 0x0002A298 File Offset: 0x00028498
	public virtual void Start()
	{
		int num = 0;
		Color color = this.MurderStreaks.color;
		float num2 = color.a = (float)num;
		Color color2 = this.MurderStreaks.color = color;
		int num3 = 0;
		Color color3 = this.Streaks.color;
		float num4 = color3.a = (float)num3;
		Color color4 = this.Streaks.color = color3;
	}

	// Token: 0x06000249 RID: 585 RVA: 0x0002A30C File Offset: 0x0002850C
	public virtual void Update()
	{
		if (this.Streaks.color.a > (float)0)
		{
			this.AlarmBloom.bloomIntensity = this.AlarmBloom.bloomIntensity - Time.deltaTime;
			float a = this.Streaks.color.a - Time.deltaTime;
			Color color = this.Streaks.color;
			float num = color.a = a;
			Color color2 = this.Streaks.color = color;
			if (this.Streaks.color.a <= (float)0)
			{
				this.AlarmBloom.enabled = false;
			}
		}
		if (this.MurderStreaks.color.a > (float)0)
		{
			float a2 = this.MurderStreaks.color.a - Time.deltaTime;
			Color color3 = this.MurderStreaks.color;
			float num2 = color3.a = a2;
			Color color4 = this.MurderStreaks.color = color3;
		}
		this.EffectStrength = (float)1 - this.Yandere.Sanity * 0.01f;
		this.Vignette.intensity = Mathf.Lerp(this.Vignette.intensity, this.EffectStrength * (float)5, Time.deltaTime);
		this.Vignette.blur = Mathf.Lerp(this.Vignette.blur, this.EffectStrength, Time.deltaTime);
		this.Vignette.chromaticAberration = Mathf.Lerp(this.Vignette.chromaticAberration, this.EffectStrength * (float)5, Time.deltaTime);
	}

	// Token: 0x0600024A RID: 586 RVA: 0x0002A4BC File Offset: 0x000286BC
	public virtual void Alarm()
	{
		this.AlarmBloom.bloomIntensity = (float)1;
		int num = 1;
		Color color = this.Streaks.color;
		float num2 = color.a = (float)num;
		Color color2 = this.Streaks.color = color;
		this.AlarmBloom.enabled = true;
		this.Yandere.Jukebox.SFX.PlayOneShot(this.Noticed);
	}

	// Token: 0x0600024B RID: 587 RVA: 0x0002A52C File Offset: 0x0002872C
	public virtual void MurderWitnessed()
	{
		int num = 1;
		Color color = this.MurderStreaks.color;
		float num2 = color.a = (float)num;
		Color color2 = this.MurderStreaks.color = color;
		if (!this.Yandere.Noticed)
		{
			this.Yandere.Jukebox.SFX.PlayOneShot(this.MurderNoticed);
		}
		else
		{
			this.Yandere.Jukebox.SFX.PlayOneShot(this.SenpaiNoticed);
		}
	}

	// Token: 0x0600024C RID: 588 RVA: 0x0002A5B4 File Offset: 0x000287B4
	public virtual void DisableCamera()
	{
		if (!this.OneCamera)
		{
			this.OneCamera = true;
			if (this.Yandere.Aiming)
			{
				this.Yandere.MainCamera.clearFlags = CameraClearFlags.Color;
				this.Yandere.MainCamera.farClipPlane = 0.02f;
			}
		}
		else
		{
			this.OneCamera = false;
			if (this.Yandere.Aiming)
			{
				this.Yandere.MainCamera.clearFlags = CameraClearFlags.Skybox;
				this.Yandere.MainCamera.farClipPlane = (float)PlayerPrefs.GetInt("DrawDistance");
			}
		}
	}

	// Token: 0x0600024D RID: 589 RVA: 0x0002A654 File Offset: 0x00028854
	public virtual void Main()
	{
	}

	// Token: 0x040004EA RID: 1258
	public YandereScript Yandere;

	// Token: 0x040004EB RID: 1259
	public Vignetting Vignette;

	// Token: 0x040004EC RID: 1260
	public UITexture MurderStreaks;

	// Token: 0x040004ED RID: 1261
	public UITexture Streaks;

	// Token: 0x040004EE RID: 1262
	public Bloom AlarmBloom;

	// Token: 0x040004EF RID: 1263
	public float EffectStrength;

	// Token: 0x040004F0 RID: 1264
	public Bloom QualityBloom;

	// Token: 0x040004F1 RID: 1265
	public Vignetting QualityVignetting;

	// Token: 0x040004F2 RID: 1266
	public AntialiasingAsPostEffect QualityAntialiasingAsPostEffect;

	// Token: 0x040004F3 RID: 1267
	public bool OneCamera;

	// Token: 0x040004F4 RID: 1268
	public AudioClip MurderNoticed;

	// Token: 0x040004F5 RID: 1269
	public AudioClip SenpaiNoticed;

	// Token: 0x040004F6 RID: 1270
	public AudioClip Noticed;
}
