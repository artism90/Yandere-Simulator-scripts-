using System;
using UnityEngine;

// Token: 0x0200003E RID: 62
[Serializable]
public class HatredScript : MonoBehaviour
{
	// Token: 0x060001CB RID: 459 RVA: 0x00021774 File Offset: 0x0001F974
	public virtual void Start()
	{
		this.Character.active = false;
	}

	// Token: 0x060001CC RID: 460 RVA: 0x00021784 File Offset: 0x0001F984
	public virtual void Main()
	{
	}

	// Token: 0x040003C7 RID: 967
	public DepthOfFieldScatter DepthOfField;

	// Token: 0x040003C8 RID: 968
	public HomeDarknessScript HomeDarkness;

	// Token: 0x040003C9 RID: 969
	public HomeCameraScript HomeCamera;

	// Token: 0x040003CA RID: 970
	public GrayscaleEffect Grayscale;

	// Token: 0x040003CB RID: 971
	public Bloom Bloom;

	// Token: 0x040003CC RID: 972
	public GameObject CrackPanel;

	// Token: 0x040003CD RID: 973
	public AudioSource Voiceover;

	// Token: 0x040003CE RID: 974
	public GameObject SenpaiPhoto;

	// Token: 0x040003CF RID: 975
	public GameObject RivalPhotos;

	// Token: 0x040003D0 RID: 976
	public GameObject Character;

	// Token: 0x040003D1 RID: 977
	public GameObject Panties;

	// Token: 0x040003D2 RID: 978
	public GameObject Yandere;

	// Token: 0x040003D3 RID: 979
	public GameObject Shrine;

	// Token: 0x040003D4 RID: 980
	public Transform AntennaeR;

	// Token: 0x040003D5 RID: 981
	public Transform AntennaeL;

	// Token: 0x040003D6 RID: 982
	public Transform Corkboard;

	// Token: 0x040003D7 RID: 983
	public UISprite CrackDarkness;

	// Token: 0x040003D8 RID: 984
	public UISprite Darkness;

	// Token: 0x040003D9 RID: 985
	public UITexture Crack;

	// Token: 0x040003DA RID: 986
	public UITexture Logo;

	// Token: 0x040003DB RID: 987
	public bool Begin;

	// Token: 0x040003DC RID: 988
	public float Timer;

	// Token: 0x040003DD RID: 989
	public int Phase;

	// Token: 0x040003DE RID: 990
	public Texture[] CrackTexture;
}
