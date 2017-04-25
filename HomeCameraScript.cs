using System;
using UnityEngine;

// Token: 0x020000AC RID: 172
[Serializable]
public class HomeCameraScript : MonoBehaviour
{
	// Token: 0x060003C7 RID: 967 RVA: 0x0004B7CC File Offset: 0x000499CC
	public virtual void Start()
	{
		int num = 0;
		Color color = this.Button.color;
		float num2 = color.a = (float)num;
		Color color2 = this.Button.color = color;
		this.Focus.position = this.Target.position;
		this.transform.position = this.Destination.position;
		if (PlayerPrefs.GetInt("Night") == 1)
		{
			this.CeilingLight.active = true;
			this.NightLight.active = true;
			this.DayLight.active = false;
			this.Triggers[7].Disable();
			this.BasementJukebox.clip = this.NightBasement;
			this.RoomJukebox.clip = this.NightRoom;
			this.PlayMusic();
			this.PantiesMangaLabel.text = "Read Manga";
		}
		else
		{
			this.BasementJukebox.Play();
			this.RoomJukebox.Play();
			this.ComputerScreen.active = false;
			this.Triggers[2].Disable();
			this.Triggers[3].Disable();
			this.Triggers[5].Disable();
			this.Triggers[9].Disable();
		}
		if (PlayerPrefs.GetInt("KidnapVictim") == 0)
		{
			this.RopeGroup.active = false;
			this.Tripod.active = false;
			this.Victim.active = false;
			this.Triggers[10].Disable();
		}
		else
		{
			int @int = PlayerPrefs.GetInt("KidnapVictim");
			if (PlayerPrefs.GetInt("Student_" + @int + "_Arrested") == 1 || PlayerPrefs.GetInt("Student_" + @int + "_Dead") == 1)
			{
				this.RopeGroup.active = false;
				this.Victim.active = false;
				this.Triggers[10].Disable();
			}
		}
		Time.timeScale = (float)1;
	}

	// Token: 0x060003C8 RID: 968 RVA: 0x0004B9D4 File Offset: 0x00049BD4
	public virtual void LateUpdate()
	{
		if (this.HomeYandere.transform.position.y > (float)-5)
		{
			float x = this.HomeYandere.transform.position.x * (float)-1;
			Vector3 position = this.Destinations[0].position;
			float num = position.x = x;
			Vector3 vector = this.Destinations[0].position = position;
		}
		this.Focus.position = Vector3.Lerp(this.Focus.position, this.Target.position, Time.deltaTime * (float)10);
		this.transform.position = Vector3.Lerp(this.transform.position, this.Destination.position, Time.deltaTime * (float)10);
		this.transform.LookAt(this.Focus.position);
		if (this.ID < 11 && Input.GetButtonDown("A") && this.HomeYandere.CanMove && this.ID != 0)
		{
			this.Destination = this.Destinations[this.ID];
			this.Target = this.Targets[this.ID];
			this.HomeWindows[this.ID].Show = true;
			this.HomeYandere.CanMove = false;
			if (this.ID == 1 || this.ID == 8)
			{
				this.HomeExit.enabled = true;
			}
			else if (this.ID == 2)
			{
				this.HomeSleep.enabled = true;
			}
			else if (this.ID == 3)
			{
				this.HomeInternet.enabled = true;
			}
			else if (this.ID == 4)
			{
				this.CorkboardLabel.active = false;
				this.HomeCorkboard.enabled = true;
				this.LoadingScreen.active = true;
				this.HomeYandere.active = false;
			}
			else if (this.ID == 5)
			{
				this.HomeYandere.enabled = false;
				this.Controller.transform.localPosition = new Vector3(0.1245f, 0.032f, (float)0);
				this.HomeYandere.transform.position = new Vector3((float)1, (float)0, (float)0);
				this.HomeYandere.transform.eulerAngles = new Vector3((float)0, (float)90, (float)0);
				this.HomeYandere.Character.animation.Play("f02_gaming_00");
				this.PromptBar.ClearButtons();
				this.PromptBar.Label[0].text = "Play";
				this.PromptBar.Label[1].text = "Back";
				this.PromptBar.Label[4].text = "Select";
				this.PromptBar.UpdateButtons();
				this.PromptBar.Show = true;
			}
			else if (this.ID == 6)
			{
				this.HomeSenpaiShrine.enabled = true;
				this.HomeYandere.active = false;
			}
			else if (this.ID == 7)
			{
				this.HomePantyChanger.enabled = true;
			}
			else if (this.ID == 9)
			{
				this.HomeManga.enabled = true;
			}
			else if (this.ID == 10)
			{
				this.PromptBar.ClearButtons();
				this.PromptBar.Label[0].text = "Accept";
				this.PromptBar.Label[1].text = "Back";
				this.PromptBar.UpdateButtons();
				this.PromptBar.Show = true;
				this.HomePrisoner.UpdateDesc();
				this.HomeYandere.active = false;
			}
		}
		if (this.Destination == this.Destinations[0])
		{
			if (this.HomeYandere.transform.position.y > (float)-1)
			{
				this.Vignette.intensity = Mathf.MoveTowards(this.Vignette.intensity, (float)1, Time.deltaTime);
			}
			else
			{
				this.Vignette.intensity = Mathf.MoveTowards(this.Vignette.intensity, (float)5, Time.deltaTime * (float)5);
			}
			this.Vignette.chromaticAberration = Mathf.MoveTowards(this.Vignette.chromaticAberration, (float)1, Time.deltaTime);
			this.Vignette.blur = Mathf.MoveTowards(this.Vignette.blur, (float)1, Time.deltaTime);
		}
		else
		{
			if (this.HomeYandere.transform.position.y > (float)-1)
			{
				this.Vignette.intensity = Mathf.MoveTowards(this.Vignette.intensity, (float)0, Time.deltaTime);
			}
			else
			{
				this.Vignette.intensity = Mathf.MoveTowards(this.Vignette.intensity, (float)0, Time.deltaTime * (float)5);
			}
			this.Vignette.chromaticAberration = Mathf.MoveTowards(this.Vignette.chromaticAberration, (float)0, Time.deltaTime);
			this.Vignette.blur = Mathf.MoveTowards(this.Vignette.blur, (float)0, Time.deltaTime);
		}
		if (this.ID > 0 && this.HomeYandere.CanMove)
		{
			float a = Mathf.MoveTowards(this.Button.color.a, (float)1, Time.deltaTime * (float)10);
			Color color = this.Button.color;
			float num2 = color.a = a;
			Color color2 = this.Button.color = color;
		}
		else
		{
			float a2 = Mathf.MoveTowards(this.Button.color.a, (float)0, Time.deltaTime * (float)10);
			Color color3 = this.Button.color;
			float num3 = color3.a = a2;
			Color color4 = this.Button.color = color3;
		}
		if (this.HomeDarkness.FadeOut)
		{
			this.BasementJukebox.volume = Mathf.MoveTowards(this.BasementJukebox.volume, (float)0, Time.deltaTime);
			this.RoomJukebox.volume = Mathf.MoveTowards(this.RoomJukebox.volume, (float)0, Time.deltaTime);
		}
		else if (this.HomeYandere.transform.position.y > (float)-1)
		{
			this.BasementJukebox.volume = Mathf.MoveTowards(this.BasementJukebox.volume, (float)0, Time.deltaTime);
			this.RoomJukebox.volume = Mathf.MoveTowards(this.RoomJukebox.volume, (float)1, Time.deltaTime);
		}
		else if (!this.Torturing)
		{
			this.BasementJukebox.volume = Mathf.MoveTowards(this.BasementJukebox.volume, (float)1, Time.deltaTime);
			this.RoomJukebox.volume = Mathf.MoveTowards(this.RoomJukebox.volume, (float)0, Time.deltaTime);
		}
		if (Input.GetKeyDown("`"))
		{
			if (PlayerPrefs.GetInt("Night") == 0)
			{
				PlayerPrefs.SetInt("Night", 1);
			}
			else
			{
				PlayerPrefs.SetInt("Night", 0);
			}
			Application.LoadLevel(Application.loadedLevel);
		}
		if (Input.GetKeyDown("="))
		{
			Time.timeScale = (float)100;
		}
	}

	// Token: 0x060003C9 RID: 969 RVA: 0x0004C170 File Offset: 0x0004A370
	public virtual void PlayMusic()
	{
		if (PlayerPrefs.GetInt("DraculaDefeated") == 0)
		{
			if (!this.BasementJukebox.isPlaying)
			{
				this.BasementJukebox.Play();
			}
			if (!this.RoomJukebox.isPlaying)
			{
				this.RoomJukebox.Play();
			}
		}
	}

	// Token: 0x060003CA RID: 970 RVA: 0x0004C1C4 File Offset: 0x0004A3C4
	public virtual void Main()
	{
	}

	// Token: 0x04000954 RID: 2388
	public HomeWindowScript[] HomeWindows;

	// Token: 0x04000955 RID: 2389
	public HomeTriggerScript[] Triggers;

	// Token: 0x04000956 RID: 2390
	public HomePantyChangerScript HomePantyChanger;

	// Token: 0x04000957 RID: 2391
	public HomeSenpaiShrineScript HomeSenpaiShrine;

	// Token: 0x04000958 RID: 2392
	public HomeVideoGamesScript HomeVideoGames;

	// Token: 0x04000959 RID: 2393
	public HomeCorkboardScript HomeCorkboard;

	// Token: 0x0400095A RID: 2394
	public HomeDarknessScript HomeDarkness;

	// Token: 0x0400095B RID: 2395
	public HomeInternetScript HomeInternet;

	// Token: 0x0400095C RID: 2396
	public HomePrisonerScript HomePrisoner;

	// Token: 0x0400095D RID: 2397
	public HomeYandereScript HomeYandere;

	// Token: 0x0400095E RID: 2398
	public HomeMangaScript HomeManga;

	// Token: 0x0400095F RID: 2399
	public HomeSleepScript HomeSleep;

	// Token: 0x04000960 RID: 2400
	public HomeExitScript HomeExit;

	// Token: 0x04000961 RID: 2401
	public PromptBarScript PromptBar;

	// Token: 0x04000962 RID: 2402
	public Vignetting Vignette;

	// Token: 0x04000963 RID: 2403
	public UILabel PantiesMangaLabel;

	// Token: 0x04000964 RID: 2404
	public UISprite Button;

	// Token: 0x04000965 RID: 2405
	public GameObject ComputerScreen;

	// Token: 0x04000966 RID: 2406
	public GameObject CorkboardLabel;

	// Token: 0x04000967 RID: 2407
	public GameObject LoadingScreen;

	// Token: 0x04000968 RID: 2408
	public GameObject CeilingLight;

	// Token: 0x04000969 RID: 2409
	public GameObject Controller;

	// Token: 0x0400096A RID: 2410
	public GameObject NightLight;

	// Token: 0x0400096B RID: 2411
	public GameObject RopeGroup;

	// Token: 0x0400096C RID: 2412
	public GameObject DayLight;

	// Token: 0x0400096D RID: 2413
	public GameObject Tripod;

	// Token: 0x0400096E RID: 2414
	public GameObject Victim;

	// Token: 0x0400096F RID: 2415
	public Transform Destination;

	// Token: 0x04000970 RID: 2416
	public Transform Target;

	// Token: 0x04000971 RID: 2417
	public Transform Focus;

	// Token: 0x04000972 RID: 2418
	public Transform[] Destinations;

	// Token: 0x04000973 RID: 2419
	public Transform[] Targets;

	// Token: 0x04000974 RID: 2420
	public int ID;

	// Token: 0x04000975 RID: 2421
	public AudioSource BasementJukebox;

	// Token: 0x04000976 RID: 2422
	public AudioSource RoomJukebox;

	// Token: 0x04000977 RID: 2423
	public AudioClip NightBasement;

	// Token: 0x04000978 RID: 2424
	public AudioClip NightRoom;

	// Token: 0x04000979 RID: 2425
	public bool Torturing;
}
