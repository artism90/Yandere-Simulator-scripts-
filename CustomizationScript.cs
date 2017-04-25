using System;
using Boo.Lang.Runtime;
using UnityEngine;
using UnityScript.Lang;

// Token: 0x02000074 RID: 116
[Serializable]
public class CustomizationScript : MonoBehaviour
{
	// Token: 0x060002CC RID: 716 RVA: 0x00036328 File Offset: 0x00034528
	public CustomizationScript()
	{
		this.FemaleUniform = 1;
		this.MaleUniform = 1;
		this.SkinColor = 3;
		this.HairStyle = 1;
		this.HairColor = 1;
		this.EyeColor = 1;
		this.Selected = 1;
		this.Phase = 1;
		this.HairColorName = string.Empty;
		this.EyeColorName = string.Empty;
	}

	// Token: 0x060002CD RID: 717 RVA: 0x0003638C File Offset: 0x0003458C
	public virtual void Start()
	{
		this.Senpai.gameObject.active = false;
		this.Senpai.position = new Vector3((float)0, (float)-3, 2.1f);
		this.Yandere.position = new Vector3(0.5f, (float)-3, 2.1f);
		int num = 1360;
		Vector3 localPosition = this.ApologyWindow.localPosition;
		float num2 = localPosition.x = (float)num;
		Vector3 vector = this.ApologyWindow.localPosition = localPosition;
		this.CustomizePanel.alpha = (float)0;
		this.UniformPanel.alpha = (float)0;
		this.Yandere.active = false;
		this.FinishPanel.alpha = (float)0;
		this.GenderPanel.alpha = (float)0;
		this.WhitePanel.alpha = (float)1;
		this.UpdateFacialHair();
		this.UpdateHairStyle();
		this.UpdateEyes();
	}

	// Token: 0x060002CE RID: 718 RVA: 0x00036474 File Offset: 0x00034674
	public virtual void Update()
	{
		if (this.Phase == 1)
		{
			if (this.WhitePanel.alpha == (float)0)
			{
				this.GenderPanel.alpha = Mathf.MoveTowards(this.GenderPanel.alpha, (float)1, Time.deltaTime * (float)2);
				if (this.GenderPanel.alpha == (float)1)
				{
					if (Input.GetButtonDown("A"))
					{
						this.Cloud.active = true;
						this.Phase++;
					}
					if (Input.GetButtonDown("B"))
					{
						this.Apologize = true;
					}
					if (Input.GetButtonDown("X"))
					{
						this.White.color = new Color((float)0, (float)0, (float)0, (float)1);
						this.FadeOut = true;
						this.Phase = 0;
					}
				}
			}
		}
		else if (this.Phase == 2)
		{
			this.GenderPanel.alpha = Mathf.MoveTowards(this.GenderPanel.alpha, (float)0, Time.deltaTime * (float)2);
			if (this.GenderPanel.alpha == (float)0)
			{
				this.Senpai.gameObject.active = true;
				this.Phase++;
			}
		}
		else if (this.Phase == 3)
		{
			this.CustomizePanel.alpha = Mathf.MoveTowards(this.CustomizePanel.alpha, (float)1, Time.deltaTime * (float)2);
			if (this.CustomizePanel.alpha == (float)1)
			{
				float y = this.Senpai.localEulerAngles.y - Input.GetAxis("RS");
				Vector3 localEulerAngles = this.Senpai.localEulerAngles;
				float num = localEulerAngles.y = y;
				Vector3 vector = this.Senpai.localEulerAngles = localEulerAngles;
				float y2 = this.Senpai.localEulerAngles.y - Input.GetAxis("Mouse X");
				Vector3 localEulerAngles2 = this.Senpai.localEulerAngles;
				float num2 = localEulerAngles2.y = y2;
				Vector3 vector2 = this.Senpai.localEulerAngles = localEulerAngles2;
				if (Input.GetButtonDown("A"))
				{
					int num3 = 180;
					Vector3 localEulerAngles3 = this.Senpai.localEulerAngles;
					float num4 = localEulerAngles3.y = (float)num3;
					Vector3 vector3 = this.Senpai.localEulerAngles = localEulerAngles3;
					this.Phase++;
				}
				if (this.InputManager.TappedDown)
				{
					this.Selected++;
					if (this.Selected > 6)
					{
						this.Selected = 1;
					}
					int num5 = 650 - this.Selected * 150;
					Vector3 localPosition = this.Highlight.localPosition;
					float num6 = localPosition.y = (float)num5;
					Vector3 vector4 = this.Highlight.localPosition = localPosition;
				}
				else if (this.InputManager.TappedUp)
				{
					this.Selected--;
					if (this.Selected < 1)
					{
						this.Selected = 6;
					}
					int num7 = 650 - this.Selected * 150;
					Vector3 localPosition2 = this.Highlight.localPosition;
					float num8 = localPosition2.y = (float)num7;
					Vector3 vector5 = this.Highlight.localPosition = localPosition2;
				}
				if (this.InputManager.TappedRight)
				{
					if (this.Selected == 1)
					{
						this.SkinColor++;
						this.UpdateSkin();
					}
					else if (this.Selected == 2)
					{
						this.HairStyle++;
						this.UpdateHairStyle();
					}
					else if (this.Selected == 3)
					{
						this.HairColor++;
						this.UpdateColor();
					}
					else if (this.Selected == 4)
					{
						this.EyeColor++;
						this.UpdateEyes();
					}
					else if (this.Selected == 5)
					{
						this.EyeWear++;
						this.UpdateEyewear();
					}
					else if (this.Selected == 6)
					{
						this.FacialHair++;
						this.UpdateFacialHair();
					}
				}
				if (this.InputManager.TappedLeft)
				{
					if (this.Selected == 1)
					{
						this.SkinColor--;
						this.UpdateSkin();
					}
					else if (this.Selected == 2)
					{
						this.HairStyle--;
						this.UpdateHairStyle();
					}
					else if (this.Selected == 3)
					{
						this.HairColor--;
						this.UpdateColor();
					}
					else if (this.Selected == 4)
					{
						this.EyeColor--;
						this.UpdateEyes();
					}
					else if (this.Selected == 5)
					{
						this.EyeWear--;
						this.UpdateEyewear();
					}
					else if (this.Selected == 6)
					{
						this.FacialHair--;
						this.UpdateFacialHair();
					}
				}
			}
			if (this.Selected == 1)
			{
				float y3 = Mathf.Lerp(this.Senpai.position.y, (float)-1, Time.deltaTime * (float)10);
				Vector3 position = this.Senpai.position;
				float num9 = position.y = y3;
				Vector3 vector6 = this.Senpai.position = position;
				float z = Mathf.Lerp(this.Senpai.position.z, 2.1f, Time.deltaTime * (float)10);
				Vector3 position2 = this.Senpai.position;
				float num10 = position2.z = z;
				Vector3 vector7 = this.Senpai.position = position2;
			}
			else
			{
				float y4 = Mathf.Lerp(this.Senpai.position.y, -1.6f, Time.deltaTime * (float)10);
				Vector3 position3 = this.Senpai.position;
				float num11 = position3.y = y4;
				Vector3 vector8 = this.Senpai.position = position3;
				float z2 = Mathf.Lerp(this.Senpai.position.z, 0.4f, Time.deltaTime * (float)10);
				Vector3 position4 = this.Senpai.position;
				float num12 = position4.z = z2;
				Vector3 vector9 = this.Senpai.position = position4;
			}
		}
		else if (this.Phase == 4)
		{
			float y5 = Mathf.Lerp(this.Senpai.position.y, -0.6333333f, Time.deltaTime * (float)10);
			Vector3 position5 = this.Senpai.position;
			float num13 = position5.y = y5;
			Vector3 vector10 = this.Senpai.position = position5;
			float z3 = Mathf.Lerp(this.Senpai.position.z, 2.1f, Time.deltaTime * (float)10);
			Vector3 position6 = this.Senpai.position;
			float num14 = position6.z = z3;
			Vector3 vector11 = this.Senpai.position = position6;
			this.CustomizePanel.alpha = Mathf.MoveTowards(this.CustomizePanel.alpha, (float)0, Time.deltaTime * (float)2);
			if (this.CustomizePanel.alpha == (float)0)
			{
				this.Phase++;
			}
		}
		else if (this.Phase == 5)
		{
			this.FinishPanel.alpha = Mathf.MoveTowards(this.FinishPanel.alpha, (float)1, Time.deltaTime * (float)2);
			if (this.FinishPanel.alpha == (float)1)
			{
				if (Input.GetButtonDown("A"))
				{
					this.BigCloud.active = true;
					this.Phase++;
				}
				if (Input.GetButtonDown("B"))
				{
					this.Selected = 1;
					int num15 = 650 - this.Selected * 150;
					Vector3 localPosition3 = this.Highlight.localPosition;
					float num16 = localPosition3.y = (float)num15;
					Vector3 vector12 = this.Highlight.localPosition = localPosition3;
					this.Phase = 100;
				}
			}
		}
		else if (this.Phase == 6)
		{
			this.FinishPanel.alpha = Mathf.MoveTowards(this.FinishPanel.alpha, (float)0, Time.deltaTime * (float)2);
			if (this.FinishPanel.alpha == (float)0)
			{
				this.UpdateFemaleUniform();
				this.UpdateMaleUniform();
				this.CensorCloud.active = false;
				this.Yandere.active = true;
				this.Selected = 1;
				this.Phase++;
			}
		}
		else if (this.Phase == 7)
		{
			this.UniformPanel.alpha = Mathf.MoveTowards(this.UniformPanel.alpha, (float)1, Time.deltaTime * (float)2);
			float x = Mathf.Lerp(this.Senpai.position.x, -0.5f, Time.deltaTime * (float)10);
			Vector3 position7 = this.Senpai.position;
			float num17 = position7.x = x;
			Vector3 vector13 = this.Senpai.position = position7;
			float y6 = Mathf.Lerp(this.Senpai.position.y, (float)-1, Time.deltaTime * (float)10);
			Vector3 position8 = this.Senpai.position;
			float num18 = position8.y = y6;
			Vector3 vector14 = this.Senpai.position = position8;
			float x2 = Mathf.Lerp(this.Yandere.position.x, 0.5f, Time.deltaTime * (float)10);
			Vector3 position9 = this.Yandere.position;
			float num19 = position9.x = x2;
			Vector3 vector15 = this.Yandere.position = position9;
			float y7 = Mathf.Lerp(this.Yandere.position.y, (float)-1, Time.deltaTime * (float)10);
			Vector3 position10 = this.Yandere.position;
			float num20 = position10.y = y7;
			Vector3 vector16 = this.Yandere.position = position10;
			if (this.UniformPanel.alpha == (float)1)
			{
				if (this.Selected == 1)
				{
					float y8 = this.Senpai.localEulerAngles.y - Input.GetAxis("RS");
					Vector3 localEulerAngles4 = this.Senpai.localEulerAngles;
					float num21 = localEulerAngles4.y = y8;
					Vector3 vector17 = this.Senpai.localEulerAngles = localEulerAngles4;
					float y9 = this.Senpai.localEulerAngles.y - Input.GetAxis("Mouse X");
					Vector3 localEulerAngles5 = this.Senpai.localEulerAngles;
					float num22 = localEulerAngles5.y = y9;
					Vector3 vector18 = this.Senpai.localEulerAngles = localEulerAngles5;
				}
				else
				{
					float y10 = this.Yandere.localEulerAngles.y - Input.GetAxis("RS");
					Vector3 localEulerAngles6 = this.Yandere.localEulerAngles;
					float num23 = localEulerAngles6.y = y10;
					Vector3 vector19 = this.Yandere.localEulerAngles = localEulerAngles6;
					float y11 = this.Yandere.localEulerAngles.y - Input.GetAxis("Mouse X");
					Vector3 localEulerAngles7 = this.Yandere.localEulerAngles;
					float num24 = localEulerAngles7.y = y11;
					Vector3 vector20 = this.Yandere.localEulerAngles = localEulerAngles7;
				}
				if (Input.GetButtonDown("A"))
				{
					int num25 = 180;
					Vector3 localEulerAngles8 = this.Yandere.localEulerAngles;
					float num26 = localEulerAngles8.y = (float)num25;
					Vector3 vector21 = this.Yandere.localEulerAngles = localEulerAngles8;
					int num27 = 180;
					Vector3 localEulerAngles9 = this.Senpai.localEulerAngles;
					float num28 = localEulerAngles9.y = (float)num27;
					Vector3 vector22 = this.Senpai.localEulerAngles = localEulerAngles9;
					this.Phase++;
				}
				if (this.InputManager.TappedDown || this.InputManager.TappedUp)
				{
					if (this.Selected == 1)
					{
						this.Selected = 2;
					}
					else
					{
						this.Selected = 1;
					}
					int num29 = 650 - this.Selected * 150;
					Vector3 localPosition4 = this.UniformHighlight.localPosition;
					float num30 = localPosition4.y = (float)num29;
					Vector3 vector23 = this.UniformHighlight.localPosition = localPosition4;
				}
				if (this.InputManager.TappedRight)
				{
					if (this.Selected == 1)
					{
						this.MaleUniform++;
						this.UpdateMaleUniform();
					}
					else if (this.Selected == 2)
					{
						this.FemaleUniform++;
						this.UpdateFemaleUniform();
					}
				}
				if (this.InputManager.TappedLeft)
				{
					if (this.Selected == 1)
					{
						this.MaleUniform--;
						this.UpdateMaleUniform();
					}
					else if (this.Selected == 2)
					{
						this.FemaleUniform--;
						this.UpdateFemaleUniform();
					}
				}
			}
		}
		else if (this.Phase == 8)
		{
			float y12 = Mathf.Lerp(this.Senpai.position.y, -0.6333333f, Time.deltaTime * (float)10);
			Vector3 position11 = this.Senpai.position;
			float num31 = position11.y = y12;
			Vector3 vector24 = this.Senpai.position = position11;
			float y13 = Mathf.Lerp(this.Yandere.position.y, -0.6333333f, Time.deltaTime * (float)10);
			Vector3 position12 = this.Yandere.position;
			float num32 = position12.y = y13;
			Vector3 vector25 = this.Yandere.position = position12;
			this.UniformPanel.alpha = Mathf.MoveTowards(this.UniformPanel.alpha, (float)0, Time.deltaTime * (float)2);
			if (this.UniformPanel.alpha == (float)0)
			{
				this.Phase++;
			}
		}
		else if (this.Phase == 9)
		{
			float y14 = Mathf.Lerp(this.Senpai.position.y, -0.6333333f, Time.deltaTime * (float)10);
			Vector3 position13 = this.Senpai.position;
			float num33 = position13.y = y14;
			Vector3 vector26 = this.Senpai.position = position13;
			float y15 = Mathf.Lerp(this.Yandere.position.y, -0.6333333f, Time.deltaTime * (float)10);
			Vector3 position14 = this.Yandere.position;
			float num34 = position14.y = y15;
			Vector3 vector27 = this.Yandere.position = position14;
			this.FinishPanel.alpha = Mathf.MoveTowards(this.FinishPanel.alpha, (float)1, Time.deltaTime * (float)2);
			if (this.FinishPanel.alpha == (float)1)
			{
				if (Input.GetButtonDown("A"))
				{
					this.Phase++;
				}
				if (Input.GetButtonDown("B"))
				{
					this.Selected = 1;
					int num35 = 650 - this.Selected * 150;
					Vector3 localPosition5 = this.UniformHighlight.localPosition;
					float num36 = localPosition5.y = (float)num35;
					Vector3 vector28 = this.UniformHighlight.localPosition = localPosition5;
					this.Phase = 99;
				}
			}
		}
		else if (this.Phase == 10)
		{
			this.FinishPanel.alpha = Mathf.MoveTowards(this.FinishPanel.alpha, (float)0, Time.deltaTime * (float)2);
			if (this.FinishPanel.alpha == (float)0)
			{
				this.White.color = new Color((float)0, (float)0, (float)0, (float)1);
				this.FadeOut = true;
				this.Phase = 0;
			}
		}
		else if (this.Phase == 99)
		{
			this.FinishPanel.alpha = Mathf.MoveTowards(this.FinishPanel.alpha, (float)0, Time.deltaTime * (float)2);
			if (this.FinishPanel.alpha == (float)0)
			{
				this.Phase = 7;
			}
		}
		else if (this.Phase == 100)
		{
			this.FinishPanel.alpha = Mathf.MoveTowards(this.FinishPanel.alpha, (float)0, Time.deltaTime * (float)2);
			if (this.FinishPanel.alpha == (float)0)
			{
				this.Phase = 3;
			}
		}
		if (this.FadeOut)
		{
			this.WhitePanel.alpha = Mathf.MoveTowards(this.WhitePanel.alpha, (float)1, Time.deltaTime);
			this.audio.volume = (float)1 - this.WhitePanel.alpha;
			if (this.WhitePanel.alpha == (float)1)
			{
				PlayerPrefs.SetInt("CustomSenpai", 1);
				PlayerPrefs.SetInt("SenpaiSkinColor", this.SkinColor);
				PlayerPrefs.SetInt("SenpaiHairStyle", this.HairStyle);
				PlayerPrefs.SetString("SenpaiHairColor", this.HairColorName);
				PlayerPrefs.SetString("SenpaiEyeColor", this.EyeColorName);
				PlayerPrefs.SetInt("SenpaiEyeWear", this.EyeWear);
				PlayerPrefs.SetInt("SenpaiFacialHair", this.FacialHair);
				PlayerPrefs.SetInt("MaleUniform", this.MaleUniform);
				PlayerPrefs.SetInt("FemaleUniform", this.FemaleUniform);
				Application.LoadLevel("IntroScene");
			}
		}
		else
		{
			this.WhitePanel.alpha = Mathf.MoveTowards(this.WhitePanel.alpha, (float)0, Time.deltaTime);
		}
		if (this.Apologize)
		{
			this.Timer += Time.deltaTime;
			if (this.Timer < (float)1)
			{
				float x3 = Mathf.Lerp(this.ApologyWindow.localPosition.x, (float)0, Time.deltaTime * (float)10);
				Vector3 localPosition6 = this.ApologyWindow.localPosition;
				float num37 = localPosition6.x = x3;
				Vector3 vector29 = this.ApologyWindow.localPosition = localPosition6;
			}
			else
			{
				float x4 = this.ApologyWindow.localPosition.x - Time.deltaTime;
				Vector3 localPosition7 = this.ApologyWindow.localPosition;
				float num38 = localPosition7.x = x4;
				Vector3 vector30 = this.ApologyWindow.localPosition = localPosition7;
				float x5 = this.ApologyWindow.localPosition.x - Mathf.Abs(this.ApologyWindow.localPosition.x * 0.01f) * Time.deltaTime * (float)1000;
				Vector3 localPosition8 = this.ApologyWindow.localPosition;
				float num39 = localPosition8.x = x5;
				Vector3 vector31 = this.ApologyWindow.localPosition = localPosition8;
				if (this.ApologyWindow.localPosition.x < (float)-1360)
				{
					int num40 = 1360;
					Vector3 localPosition9 = this.ApologyWindow.localPosition;
					float num41 = localPosition9.x = (float)num40;
					Vector3 vector32 = this.ApologyWindow.localPosition = localPosition9;
					this.Apologize = false;
					this.Timer = (float)0;
				}
			}
		}
		if (Input.GetKeyDown("left ctrl"))
		{
			this.GenderPanel.alpha = (float)0;
			this.Senpai.active = true;
			this.Phase = 6;
		}
	}

	// Token: 0x060002CF RID: 719 RVA: 0x0003791C File Offset: 0x00035B1C
	public virtual void UpdateSkin()
	{
		if (this.SkinColor > 5)
		{
			this.SkinColor = 1;
		}
		else if (this.SkinColor < 1)
		{
			this.SkinColor = 5;
		}
		this.SenpaiRenderer.materials[2].mainTexture = this.FaceTextures[this.SkinColor];
		this.SenpaiRenderer.materials[0].mainTexture = this.SkinTextures[this.SkinColor];
		this.SkinColorLabel.text = "Skin Color " + this.SkinColor;
	}

	// Token: 0x060002D0 RID: 720 RVA: 0x000379B4 File Offset: 0x00035BB4
	public virtual void UpdateHairStyle()
	{
		if (this.HairStyle > Extensions.get_length(this.Hairstyles) - 1)
		{
			this.HairStyle = 0;
		}
		else if (this.HairStyle < 0)
		{
			this.HairStyle = Extensions.get_length(this.Hairstyles) - 1;
		}
		for (int i = 1; i < Extensions.get_length(this.Hairstyles); i++)
		{
			this.Hairstyles[i].active = false;
		}
		if (this.HairStyle > 0)
		{
			this.HairRenderer = (Renderer)this.Hairstyles[this.HairStyle].GetComponent(typeof(Renderer));
			this.Hairstyles[this.HairStyle].active = true;
		}
		this.HairStyleLabel.text = "Hair Style " + this.HairStyle;
		this.UpdateColor();
	}

	// Token: 0x060002D1 RID: 721 RVA: 0x00037A9C File Offset: 0x00035C9C
	public virtual void UpdateFacialHair()
	{
		if (this.FacialHair > Extensions.get_length(this.FacialHairstyles) - 1)
		{
			this.FacialHair = 0;
		}
		else if (this.FacialHair < 0)
		{
			this.FacialHair = Extensions.get_length(this.FacialHairstyles) - 1;
		}
		for (int i = 1; i < Extensions.get_length(this.FacialHairstyles); i++)
		{
			this.FacialHairstyles[i].active = false;
		}
		if (this.FacialHair > 0)
		{
			this.FacialHairRenderer = (Renderer)this.FacialHairstyles[this.FacialHair].GetComponent(typeof(Renderer));
			this.FacialHairstyles[this.FacialHair].active = true;
		}
		this.FacialHairStyleLabel.text = "Facial Hair " + this.FacialHair;
		this.UpdateColor();
	}

	// Token: 0x060002D2 RID: 722 RVA: 0x00037B84 File Offset: 0x00035D84
	public virtual void UpdateColor()
	{
		if (this.HairColor > 10)
		{
			this.HairColor = 1;
		}
		else if (this.HairColor < 1)
		{
			this.HairColor = 10;
		}
		Color color;
		if (this.HairColor == 1)
		{
			color = new Color(0.5f, 0.5f, 0.5f);
			this.HairColorName = "Black";
		}
		else if (this.HairColor == 2)
		{
			color = new Color((float)1, (float)0, (float)0);
			this.HairColorName = "Red";
		}
		else if (this.HairColor == 3)
		{
			color = new Color((float)1, (float)1, (float)0);
			this.HairColorName = "Yellow";
		}
		else if (this.HairColor == 4)
		{
			color = new Color((float)0, (float)1, (float)0);
			this.HairColorName = "Green";
		}
		else if (this.HairColor == 5)
		{
			color = new Color((float)0, (float)1, (float)1);
			this.HairColorName = "Cyan";
		}
		else if (this.HairColor == 6)
		{
			color = new Color((float)0, (float)0, (float)1);
			this.HairColorName = "Blue";
		}
		else if (this.HairColor == 7)
		{
			color = new Color((float)1, (float)0, (float)1);
			this.HairColorName = "Purple";
		}
		else if (this.HairColor == 8)
		{
			color = new Color((float)1, 0.5f, (float)0);
			this.HairColorName = "Orange";
		}
		else if (this.HairColor == 9)
		{
			color = new Color(0.5f, 0.25f, (float)0);
			this.HairColorName = "Brown";
		}
		else if (this.HairColor == 10)
		{
			color = new Color((float)1, (float)1, (float)1);
			this.HairColorName = "White";
		}
		if (this.HairStyle > 0)
		{
			this.HairRenderer = (Renderer)this.Hairstyles[this.HairStyle].GetComponent(typeof(Renderer));
			this.HairRenderer.material.color = color;
		}
		if (this.FacialHair > 0)
		{
			this.FacialHairRenderer = (Renderer)this.FacialHairstyles[this.FacialHair].GetComponent(typeof(Renderer));
			this.FacialHairRenderer.material.color = color;
			if (Extensions.get_length(this.FacialHairRenderer.materials) > 1)
			{
				this.FacialHairRenderer.materials[1].color = color;
			}
		}
		this.HairColorLabel.text = "Hair Color " + this.HairColor;
	}

	// Token: 0x060002D3 RID: 723 RVA: 0x00037E30 File Offset: 0x00036030
	public virtual void UpdateEyes()
	{
		if (this.EyeColor > 10)
		{
			this.EyeColor = 1;
		}
		else if (this.EyeColor < 1)
		{
			this.EyeColor = 10;
		}
		Color color = default(Color);
		if (this.EyeColor == 1)
		{
			color = new Color(0.5f, 0.5f, 0.5f);
			this.EyeColorName = "Black";
		}
		else if (this.EyeColor == 2)
		{
			color = new Color((float)1, (float)0, (float)0);
			this.EyeColorName = "Red";
		}
		else if (this.EyeColor == 3)
		{
			color = new Color((float)1, (float)1, (float)0);
			this.EyeColorName = "Yellow";
		}
		else if (this.EyeColor == 4)
		{
			color = new Color((float)0, (float)1, (float)0);
			this.EyeColorName = "Green";
		}
		else if (this.EyeColor == 5)
		{
			color = new Color((float)0, (float)1, (float)1);
			this.EyeColorName = "Cyan";
		}
		else if (this.EyeColor == 6)
		{
			color = new Color((float)0, (float)0, (float)1);
			this.EyeColorName = "Blue";
		}
		else if (this.EyeColor == 7)
		{
			color = new Color((float)1, (float)0, (float)1);
			this.EyeColorName = "Purple";
		}
		else if (this.EyeColor == 8)
		{
			color = new Color((float)1, 0.5f, (float)0);
			this.EyeColorName = "Orange";
		}
		else if (this.EyeColor == 9)
		{
			color = new Color(0.5f, 0.25f, (float)0);
			this.EyeColorName = "Brown";
		}
		else if (this.EyeColor == 10)
		{
			color = new Color((float)1, (float)1, (float)1);
			this.EyeColorName = "White";
		}
		this.EyeR.material.color = color;
		this.EyeL.material.color = color;
		this.EyeColorLabel.text = "Eye Color " + this.EyeColor;
	}

	// Token: 0x060002D4 RID: 724 RVA: 0x00038054 File Offset: 0x00036254
	public virtual void UpdateEyewear()
	{
		if (this.EyeWear > 5)
		{
			this.EyeWear = 0;
		}
		else if (this.EyeWear < 0)
		{
			this.EyeWear = 5;
		}
		for (int i = 1; i < this.Eyewears.Length; i++)
		{
			this.Eyewears[i].active = false;
		}
		if (this.EyeWear > 0)
		{
			this.Eyewears[this.EyeWear].active = true;
		}
		this.EyeWearLabel.text = "Eye Wear " + this.EyeWear;
	}

	// Token: 0x060002D5 RID: 725 RVA: 0x000380F8 File Offset: 0x000362F8
	public virtual void UpdateMaleUniform()
	{
		if (this.MaleUniform > Extensions.get_length(this.MaleUniforms) - 1)
		{
			this.MaleUniform = 1;
		}
		else if (this.MaleUniform < 1)
		{
			this.MaleUniform = Extensions.get_length(this.MaleUniforms) - 1;
		}
		RuntimeServices.SetProperty(this.SenpaiRenderer, "sharedMesh", this.MaleUniforms[this.MaleUniform]);
		if (this.MaleUniform == 1)
		{
			this.SenpaiRenderer.materials[0].mainTexture = this.SkinTextures[this.SkinColor];
			this.SenpaiRenderer.materials[1].mainTexture = this.MaleUniformTextures[this.MaleUniform];
			this.SenpaiRenderer.materials[2].mainTexture = this.FaceTextures[this.SkinColor];
		}
		else if (this.MaleUniform == 2)
		{
			this.SenpaiRenderer.materials[0].mainTexture = this.MaleUniformTextures[this.MaleUniform];
			this.SenpaiRenderer.materials[1].mainTexture = this.FaceTextures[this.SkinColor];
			this.SenpaiRenderer.materials[2].mainTexture = this.SkinTextures[this.SkinColor];
		}
		else if (this.MaleUniform == 3)
		{
			this.SenpaiRenderer.materials[0].mainTexture = this.MaleUniformTextures[this.MaleUniform];
			this.SenpaiRenderer.materials[1].mainTexture = this.FaceTextures[this.SkinColor];
			this.SenpaiRenderer.materials[2].mainTexture = this.SkinTextures[this.SkinColor];
		}
		else if (this.MaleUniform == 4)
		{
			this.SenpaiRenderer.materials[0].mainTexture = this.FaceTextures[this.SkinColor];
			this.SenpaiRenderer.materials[1].mainTexture = this.SkinTextures[this.SkinColor];
			this.SenpaiRenderer.materials[2].mainTexture = this.MaleUniformTextures[this.MaleUniform];
		}
		else if (this.MaleUniform == 5)
		{
			this.SenpaiRenderer.materials[0].mainTexture = this.FaceTextures[this.SkinColor];
			this.SenpaiRenderer.materials[1].mainTexture = this.SkinTextures[this.SkinColor];
			this.SenpaiRenderer.materials[2].mainTexture = this.MaleUniformTextures[this.MaleUniform];
		}
		else if (this.MaleUniform == 6)
		{
			this.SenpaiRenderer.materials[0].mainTexture = this.FaceTextures[this.SkinColor];
			this.SenpaiRenderer.materials[1].mainTexture = this.SkinTextures[this.SkinColor];
			this.SenpaiRenderer.materials[2].mainTexture = this.MaleUniformTextures[this.MaleUniform];
		}
		this.MaleUniformLabel.text = "Male Uniform " + this.MaleUniform;
	}

	// Token: 0x060002D6 RID: 726 RVA: 0x00038418 File Offset: 0x00036618
	public virtual void UpdateFemaleUniform()
	{
		if (this.FemaleUniform > Extensions.get_length(this.FemaleUniforms) - 1)
		{
			this.FemaleUniform = 1;
		}
		else if (this.FemaleUniform < 1)
		{
			this.FemaleUniform = Extensions.get_length(this.FemaleUniforms) - 1;
		}
		RuntimeServices.SetProperty(this.YandereRenderer, "sharedMesh", this.FemaleUniforms[this.FemaleUniform]);
		this.YandereRenderer.materials[0].mainTexture = this.FemaleUniformTextures[this.FemaleUniform];
		this.YandereRenderer.materials[1].mainTexture = this.FemaleUniformTextures[this.FemaleUniform];
		this.YandereRenderer.materials[2].mainTexture = this.FemaleFace;
		this.YandereRenderer.materials[3].mainTexture = this.FemaleFace;
		this.FemaleUniformLabel.text = "Female Uniform " + this.FemaleUniform;
	}

	// Token: 0x060002D7 RID: 727 RVA: 0x00038514 File Offset: 0x00036714
	public virtual void Main()
	{
	}

	// Token: 0x040006A8 RID: 1704
	public InputManagerScript InputManager;

	// Token: 0x040006A9 RID: 1705
	public Renderer FacialHairRenderer;

	// Token: 0x040006AA RID: 1706
	public Renderer YandereRenderer;

	// Token: 0x040006AB RID: 1707
	public Renderer SenpaiRenderer;

	// Token: 0x040006AC RID: 1708
	public Renderer HairRenderer;

	// Token: 0x040006AD RID: 1709
	public Renderer EyeR;

	// Token: 0x040006AE RID: 1710
	public Renderer EyeL;

	// Token: 0x040006AF RID: 1711
	public Transform UniformHighlight;

	// Token: 0x040006B0 RID: 1712
	public Transform ApologyWindow;

	// Token: 0x040006B1 RID: 1713
	public Transform Highlight;

	// Token: 0x040006B2 RID: 1714
	public Transform Yandere;

	// Token: 0x040006B3 RID: 1715
	public Transform Senpai;

	// Token: 0x040006B4 RID: 1716
	public UIPanel CustomizePanel;

	// Token: 0x040006B5 RID: 1717
	public UIPanel UniformPanel;

	// Token: 0x040006B6 RID: 1718
	public UIPanel FinishPanel;

	// Token: 0x040006B7 RID: 1719
	public UIPanel GenderPanel;

	// Token: 0x040006B8 RID: 1720
	public UIPanel WhitePanel;

	// Token: 0x040006B9 RID: 1721
	public UILabel FacialHairStyleLabel;

	// Token: 0x040006BA RID: 1722
	public UILabel FemaleUniformLabel;

	// Token: 0x040006BB RID: 1723
	public UILabel MaleUniformLabel;

	// Token: 0x040006BC RID: 1724
	public UILabel SkinColorLabel;

	// Token: 0x040006BD RID: 1725
	public UILabel HairStyleLabel;

	// Token: 0x040006BE RID: 1726
	public UILabel HairColorLabel;

	// Token: 0x040006BF RID: 1727
	public UILabel EyeColorLabel;

	// Token: 0x040006C0 RID: 1728
	public UILabel EyeWearLabel;

	// Token: 0x040006C1 RID: 1729
	public GameObject CensorCloud;

	// Token: 0x040006C2 RID: 1730
	public GameObject BigCloud;

	// Token: 0x040006C3 RID: 1731
	public GameObject Cloud;

	// Token: 0x040006C4 RID: 1732
	public UISprite White;

	// Token: 0x040006C5 RID: 1733
	public bool Apologize;

	// Token: 0x040006C6 RID: 1734
	public bool FadeOut;

	// Token: 0x040006C7 RID: 1735
	public float Timer;

	// Token: 0x040006C8 RID: 1736
	public int FemaleUniform;

	// Token: 0x040006C9 RID: 1737
	public int MaleUniform;

	// Token: 0x040006CA RID: 1738
	public int FacialHair;

	// Token: 0x040006CB RID: 1739
	public int SkinColor;

	// Token: 0x040006CC RID: 1740
	public int HairStyle;

	// Token: 0x040006CD RID: 1741
	public int HairColor;

	// Token: 0x040006CE RID: 1742
	public int EyeColor;

	// Token: 0x040006CF RID: 1743
	public int EyeWear;

	// Token: 0x040006D0 RID: 1744
	public int Selected;

	// Token: 0x040006D1 RID: 1745
	public int Phase;

	// Token: 0x040006D2 RID: 1746
	public Texture[] FemaleUniformTextures;

	// Token: 0x040006D3 RID: 1747
	public Texture[] MaleUniformTextures;

	// Token: 0x040006D4 RID: 1748
	public Texture[] FaceTextures;

	// Token: 0x040006D5 RID: 1749
	public Texture[] SkinTextures;

	// Token: 0x040006D6 RID: 1750
	public GameObject[] FacialHairstyles;

	// Token: 0x040006D7 RID: 1751
	public GameObject[] Hairstyles;

	// Token: 0x040006D8 RID: 1752
	public GameObject[] Eyewears;

	// Token: 0x040006D9 RID: 1753
	public Mesh[] FemaleUniforms;

	// Token: 0x040006DA RID: 1754
	public Mesh[] MaleUniforms;

	// Token: 0x040006DB RID: 1755
	public Texture FemaleFace;

	// Token: 0x040006DC RID: 1756
	public string HairColorName;

	// Token: 0x040006DD RID: 1757
	public string EyeColorName;
}
