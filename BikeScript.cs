using System;
using UnityEngine;

// Token: 0x02000002 RID: 2
[Serializable]
public class BikeScript : MonoBehaviour
{
	// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
	public BikeScript()
	{
		this.MaxSpeed = 400f;
		this.Gears = new int[]
		{
			15,
			30,
			60,
			120,
			240,
			350,
			400
		};
		this.Torque = (float)40;
		this.MaxTorque = (float)1000;
		this.Freno = (float)-20;
	}

	// Token: 0x06000002 RID: 2 RVA: 0x000020A4 File Offset: 0x000002A4
	public virtual void Start()
	{
		this.rigidbody.centerOfMass = this.CoM.localPosition;
		this.rigidbody.interpolation = RigidbodyInterpolation.Interpolate;
		this.Jukebox.time = (float)36;
		this.Jukebox.Play();
	}

	// Token: 0x06000003 RID: 3 RVA: 0x000020EC File Offset: 0x000002EC
	public virtual void Update()
	{
		this.CurSpeed = this.transform.InverseTransformDirection(this.rigidbody.velocity).z;
		this.Rider.animation["f02_pedalBikeFast_00"].weight = (this.CurSpeed - (float)10) * 0.1f;
		if (Input.GetButton("LB"))
		{
			this.MaxSpeed = Mathf.Lerp(this.MaxSpeed, (float)20, Time.deltaTime);
		}
		else
		{
			this.MaxSpeed = Mathf.Lerp(this.MaxSpeed, (float)10, Time.deltaTime);
		}
		this.rigidbody.velocity = Vector3.MoveTowards(this.rigidbody.velocity, new Vector3((float)0, (float)0, (float)0), Time.deltaTime);
		this.Rider.animation["f02_pedalBike_00"].speed = this.CurSpeed * 0.5f;
		this.Rider.animation["f02_pedalBikeFast_00"].speed = this.CurSpeed * 0.5f;
		this.Bike.animation["Pedal"].speed = this.CurSpeed * 0.5f;
		this.WheelR.motorTorque = this.Torque * Input.GetAxis("Vertical");
		this.WheelF.steerAngle = this.SteerAngle * Input.GetAxis("Horizontal");
		this.SteerAngle = (float)45 - this.CurSpeed * 1.5f;
		if (this.WheelR.isGrounded && Input.GetButtonDown("A"))
		{
			this.rigidbody.AddForce(this.transform.up * (float)250, ForceMode.Acceleration);
		}
		if (this.WheelF.isGrounded)
		{
			this.WheelieTime = (float)0;
		}
		if (Input.GetKeyDown("`") || this.transform.position.y < (float)25)
		{
			Application.LoadLevel(Application.loadedLevel);
		}
		if (Input.GetKeyDown("0"))
		{
			Application.LoadLevel("SchoolScene");
		}
		if (Input.GetKeyDown("return"))
		{
			float y = this.transform.position.y + (float)1;
			Vector3 position = this.transform.position;
			float num = position.y = y;
			Vector3 vector = this.transform.position = position;
		}
	}

	// Token: 0x06000004 RID: 4 RVA: 0x00002378 File Offset: 0x00000578
	public virtual void FixedUpdate()
	{
		if (this.CurSpeed > (float)50 && this.WheelF.isGrounded)
		{
			this.rigidbody.angularDrag = (float)8;
		}
		else if (this.CurSpeed > (float)50 && !this.WheelF.isGrounded)
		{
			new WaitForSeconds(1.5f);
			this.rigidbody.angularDrag = (float)3;
		}
		if (!this.WheelF.isGrounded && this.WheelR.isGrounded)
		{
			this.WheelieTime += Time.deltaTime;
			if (this.WheelieTime > this.MaxWheelieTime)
			{
				this.MaxWheelieTime = this.WheelieTime;
				this.WheelieLabel.text = "Longest wheelie: " + this.MaxWheelieTime.ToString("F2") + " meters";
			}
		}
		if (this.WheelF.isGrounded && this.WheelR.isGrounded)
		{
			if (Vector3.Angle(Vector3.up, this.transform.up) > (float)45 && Input.GetAxis("Horizontal") != (float)0)
			{
				this.rigidbody.AddRelativeTorque(Vector3.forward * (float)5000 * Input.GetAxis("Horizontal"));
			}
			else
			{
				this.rigidbody.angularDrag = (float)8;
			}
		}
		else
		{
			if (Input.GetKey(KeyCode.W))
			{
				this.rigidbody.AddRelativeTorque(Vector3.right * (float)1500 * Input.GetAxis("Vertical"));
			}
			if (Input.GetKey(KeyCode.S))
			{
				this.rigidbody.AddRelativeTorque(Vector3.left * (float)-1500 * Input.GetAxis("Vertical"));
			}
			if (Input.GetKey(KeyCode.D))
			{
				this.rigidbody.AddRelativeTorque(Vector3.back * (float)550 * Input.GetAxis("Horizontal"));
			}
			if (Input.GetKey(KeyCode.A))
			{
				this.rigidbody.AddRelativeTorque(Vector3.forward * (float)-550 * Input.GetAxis("Horizontal"));
			}
		}
		RaycastHit raycastHit = default(RaycastHit);
		Vector3 vector = this.WheelF.transform.TransformPoint(this.WheelF.center);
		this.WFmesh.transform.rotation = this.WheelF.transform.rotation * Quaternion.Euler((float)0, this.WheelF.steerAngle - (float)90, this.RotVal1 * (float)-1);
		this.RotVal1 += this.WheelF.rpm * (float)6 * Time.deltaTime;
		WheelHit wheelHit = default(WheelHit);
		this.WheelF.GetGroundHit(out wheelHit);
		RaycastHit raycastHit2 = default(RaycastHit);
		Vector3 vector2 = this.WheelR.transform.TransformPoint(this.WheelR.center);
		this.WRmesh.transform.rotation = this.WheelR.transform.rotation * Quaternion.Euler((float)0, this.WheelR.steerAngle - (float)90, this.RotVal2 * (float)-1);
		this.RotVal2 += this.WheelR.rpm * (float)6 * Time.deltaTime;
		WheelHit wheelHit2 = default(WheelHit);
		this.WheelR.GetGroundHit(out wheelHit2);
		if (this.transform.eulerAngles.z > (float)0 && this.transform.eulerAngles.z < (float)180)
		{
			float z = Mathf.Lerp(this.transform.eulerAngles.z, (float)0, Time.deltaTime);
			Vector3 eulerAngles = this.transform.eulerAngles;
			float num = eulerAngles.z = z;
			Vector3 vector3 = this.transform.eulerAngles = eulerAngles;
		}
		else if (this.transform.eulerAngles.z > (float)180)
		{
			float z2 = Mathf.Lerp(this.transform.eulerAngles.z, (float)360, Time.deltaTime);
			Vector3 eulerAngles2 = this.transform.eulerAngles;
			float num2 = eulerAngles2.z = z2;
			Vector3 vector4 = this.transform.eulerAngles = eulerAngles2;
		}
		if (this.rigidbody.velocity.magnitude > this.MaxSpeed)
		{
			this.rigidbody.velocity = this.rigidbody.velocity.normalized * this.MaxSpeed;
		}
	}

	// Token: 0x06000005 RID: 5 RVA: 0x00002864 File Offset: 0x00000A64
	public virtual void Main()
	{
		this.Rider.animation["f02_pedalBikeFast_00"].layer = 1;
		this.Rider.animation.Play("f02_pedalBikeFast_00");
	}

	// Token: 0x04000002 RID: 2
	public Transform CoM;

	// Token: 0x04000003 RID: 3
	public float CurSpeed;

	// Token: 0x04000004 RID: 4
	public float MaxSpeed;

	// Token: 0x04000005 RID: 5
	public float MinSpeed;

	// Token: 0x04000006 RID: 6
	private int[] Gears;

	// Token: 0x04000007 RID: 7
	private int CurGear;

	// Token: 0x04000008 RID: 8
	private float Torque;

	// Token: 0x04000009 RID: 9
	private float MaxTorque;

	// Token: 0x0400000A RID: 10
	private float Freno;

	// Token: 0x0400000B RID: 11
	public WheelCollider WheelF;

	// Token: 0x0400000C RID: 12
	public WheelCollider WheelR;

	// Token: 0x0400000D RID: 13
	public Transform WFmesh;

	// Token: 0x0400000E RID: 14
	public Transform WRmesh;

	// Token: 0x0400000F RID: 15
	public float SteerAngle;

	// Token: 0x04000010 RID: 16
	private float RotVal1;

	// Token: 0x04000011 RID: 17
	private float RotVal2;

	// Token: 0x04000012 RID: 18
	public float WheelieTime;

	// Token: 0x04000013 RID: 19
	public float MaxWheelieTime;

	// Token: 0x04000014 RID: 20
	public GameObject Rider;

	// Token: 0x04000015 RID: 21
	public GameObject Bike;

	// Token: 0x04000016 RID: 22
	public UILabel WheelieLabel;

	// Token: 0x04000017 RID: 23
	public AudioSource Jukebox;
}
