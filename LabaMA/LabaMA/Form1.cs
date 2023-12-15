using System.Net.Http;
using System.Text;
using LabaMA.Models;
using Newtonsoft.Json;
using System.Text.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace LabaMA;

public partial class Form1 : Form
{
	private static readonly HttpClient client = new HttpClient();

	private ComputerInfo Computer { get; set; }
	private CPU Cpu { get; set; }
	private GPU Gpu { get; set; }
	private RAM Ram { get; set; }
	private SSD Ssd { get; set; }
	Random Random { get; set; }

	public Form1()
	{
		InitializeComponent();
		Random = new Random();
	}

	private async void button1_Click(object sender, EventArgs e)
	{
		var response = await client.GetAsync("http://localhost:5000/api/ComputerInfo/1");
		response.EnsureSuccessStatusCode();
		string responseBody = await response.Content.ReadAsStringAsync();
		ComputerInfo deserializedObject = JsonConvert.DeserializeObject<ComputerInfo>(responseBody);
	}

	private async void button8_Click(object sender, EventArgs e)
	{
		StringContent jsonContent;
		HttpResponseMessage response;
		switch (comboBox4.SelectedIndex)
		{
			case 0:
				Computer = new ComputerInfo
				{
					OSVersion = compVersion.Text,
					OSName = compNameOs.Text,
					SystemFolder = compFolder.Text,
					ComputerName = compName.Text,
					CreationTime = DateTime.UtcNow.ToString(),
					UpdateTime = DateTime.UtcNow.ToString()
				};

				jsonContent = new( JsonSerializer.Serialize(Computer), Encoding.UTF8, "application/json");
				response = await client.PostAsync("http://localhost:5000/api/ComputerInfo", jsonContent);
				Computer.ComputerId = JsonConvert.DeserializeObject<int>(await response.Content.ReadAsStringAsync());
				computerId.Text = Computer.ComputerId.ToString();
				break;
			case 1:
				Ram = new RAM
				{
					RAMId = Random.Next(),
					Frequency = ramFrequency.Text,
					Volume = ramVolume.Text,
					Name = ramName.Text,
				};

				jsonContent = new(JsonSerializer.Serialize(Ram), Encoding.UTF8, "application/json");
				response = await client.PostAsync($"http://localhost:5000/api/RAM", jsonContent);
				respId.Text = JsonConvert.DeserializeObject<int>(await response.Content.ReadAsStringAsync()).ToString();
				break;
			case 2:
				Cpu = new CPU
				{
					CPUId = Random.Next(),
					Frequency = cpuFreq.Text,
					Bitness = cpuBitness.Text,
					CacheMemory = cpuCacheMemoty.Text,
					Name = cpuName.Text,
					NumberOfCores = cpuNumOfCores.Text,
					ComputerId = int.Parse(computerId.Text),
				};

				jsonContent = new(JsonSerializer.Serialize(Cpu), Encoding.UTF8, "application/json");
				response = await client.PostAsync($"http://localhost:5000/api/CPU", jsonContent);
				respId.Text = JsonConvert.DeserializeObject<int>(await response.Content.ReadAsStringAsync()).ToString();
				break;
			case 3:
				Gpu = new GPU
				{
					GPUId = Random.Next(),
					Frequency = gpuFreq.Text,
					VolumeMemory = gpuVolume.Text,
					Name = gpuName.Text,
				};
				jsonContent = new(JsonSerializer.Serialize(Gpu), Encoding.UTF8, "application/json");
				response = await client.PostAsync($"http://localhost:5000/api/GPU", jsonContent);
				respId.Text = JsonConvert.DeserializeObject<int>(await response.Content.ReadAsStringAsync()).ToString();
				break;
			case 4:
				Ssd = new SSD
				{
					SSDId = Random.Next(),
					Amount = ssdAmount.Text,
					MaxSpeedRead = ssdMSR.Text,
					MaxSpeedWrite = ssdMSW.Text,
					Name = ssdName.Text
				};
				jsonContent = new(JsonSerializer.Serialize(Ssd), Encoding.UTF8, "application/json");
				response = await client.PostAsync($"http://localhost:5000/api/SSD", jsonContent);
				respId.Text = JsonConvert.DeserializeObject<int>(await response.Content.ReadAsStringAsync()).ToString();
				break;

			default: break;
		}
	}
	private async void button10_Click(object sender, EventArgs e)
	{
		StringContent jsonContent;
		HttpResponseMessage response;
		switch (comboBox4.SelectedIndex)
		{
			case 0:
				jsonContent = new(JsonSerializer.Serialize(Computer), Encoding.UTF8, "application/json");
				response = await client.DeleteAsync($"http://localhost:5000/api/ComputerInfo/{int.Parse(id.Text)}");
				break;
			case 1:
				jsonContent = new(JsonSerializer.Serialize(Ram), Encoding.UTF8, "application/json");
				response = await client.DeleteAsync($"http://localhost:5000/api/RAM/{int.Parse(id.Text)}");

				break;
			case 2:
				jsonContent = new(JsonSerializer.Serialize(Cpu), Encoding.UTF8, "application/json");
				response = await client.DeleteAsync($"http://localhost:5000/api/CPU/{int.Parse(id.Text)}");
				break;
			case 3:
				jsonContent = new(JsonSerializer.Serialize(Gpu), Encoding.UTF8, "application/json");
				response = await client.DeleteAsync($"http://localhost:5000/api/GPU/{int.Parse(id.Text)}");
				break;
			case 4:
				jsonContent = new(JsonSerializer.Serialize(Ssd), Encoding.UTF8, "application/json");
				response = await client.DeleteAsync($"http://localhost:5000/api/SSD/{int.Parse(id.Text)}");
				break;

			default: break;
		}
	}

	private async void button9_Click(object sender, EventArgs e)
	{
		StringContent jsonContent;
		HttpResponseMessage response;
		switch (comboBox4.SelectedIndex)
		{
			case 0:
				Computer = new ComputerInfo
				{
					OSVersion = compVersion.Text,
					OSName = compNameOs.Text,
					SystemFolder = compFolder.Text,
					ComputerName = compName.Text,
					CreationTime = DateTime.UtcNow.ToString(),
					UpdateTime = DateTime.UtcNow.ToString()
				};

				jsonContent = new(JsonSerializer.Serialize(Computer), Encoding.UTF8, "application/json");
				response = await client.PutAsync($"http://localhost:5000/api/ComputerInfo/{int.Parse(id.Text)}", jsonContent);
				computerId.Text = Computer.ComputerId.ToString();
				break;
			case 1:
				Ram = new RAM
				{
					Frequency = ramFrequency.Text,
					Volume = ramVolume.Text,
					Name = ramName.Text,
				};

				jsonContent = new(JsonSerializer.Serialize(Ram), Encoding.UTF8, "application/json");
				response = await client.PutAsync($"http://localhost:5000/api/RAM/{int.Parse(id.Text)}", jsonContent);

				break;
			case 2:
				Cpu = new CPU
				{
					Frequency = cpuFreq.Text,
					Bitness = cpuBitness.Text,
					CacheMemory = cpuCacheMemoty.Text,
					Name = cpuName.Text,
					NumberOfCores = cpuNumOfCores.Text,
					ComputerId = int.Parse(computerId.Text),
				};

				jsonContent = new(JsonSerializer.Serialize(Cpu), Encoding.UTF8, "application/json");
				response = await client.PutAsync($"http://localhost:5000/api/CPU/{int.Parse(id.Text)}", jsonContent);
				break;
			case 3:
				Gpu = new GPU
				{
					Frequency = gpuFreq.Text,
					VolumeMemory = gpuVolume.Text,
					Name = gpuName.Text,
				};
				jsonContent = new(JsonSerializer.Serialize(Gpu), Encoding.UTF8, "application/json");
				response = await client.PutAsync($"http://localhost:5000/api/GPU/{int.Parse(id.Text)}", jsonContent);
				break;
			case 4:
				Ssd = new SSD
				{
					Amount = ssdAmount.Text,
					MaxSpeedRead = ssdMSR.Text,
					MaxSpeedWrite = ssdMSW.Text,
					Name = ssdName.Text
				};
				jsonContent = new(JsonSerializer.Serialize(Ssd), Encoding.UTF8, "application/json");
				response = await client.PutAsync($"http://localhost:5000/api/SSD/{int.Parse(id.Text)}", jsonContent);
				break;

			default: break;
		}
	}

	private async void button11_Click(object sender, EventArgs e)
	{
		StringContent jsonContent;
		HttpResponseMessage resp;
		switch (comboBox4.SelectedIndex)
		{
			case 0:
				jsonContent = new(JsonSerializer.Serialize(Computer), Encoding.UTF8, "application/json");
				resp = await client.GetAsync($"http://localhost:5000/api/ComputerInfo/{int.Parse(id.Text)}");
				response.Text = await resp.Content.ReadAsStringAsync();
				response.Text.Replace(' ', '\n');
				break;
			case 1:
				jsonContent = new(JsonSerializer.Serialize(Ram), Encoding.UTF8, "application/json");
				resp = await client.GetAsync($"http://localhost:5000/api/RAM/{int.Parse(id.Text)}");
				response.Text = await resp.Content.ReadAsStringAsync();
				response.Text.Replace(' ', '\n');
				break;
			case 2:
				jsonContent = new(JsonSerializer.Serialize(Cpu), Encoding.UTF8, "application/json");
				resp = await client.GetAsync($"http://localhost:5000/api/CPU/{int.Parse(id.Text)}");
				response.Text = await resp.Content.ReadAsStringAsync();
				response.Text.Replace(' ', '\n');
				break;
			case 3:
				jsonContent = new(JsonSerializer.Serialize(Gpu), Encoding.UTF8, "application/json");
				resp = await client.GetAsync($"http://localhost:5000/api/GPU/{int.Parse(id.Text)}");
				response.Text = await resp.Content.ReadAsStringAsync();
				response.Text.Replace(' ', '\n');
				break;
			case 4:
				jsonContent = new(JsonSerializer.Serialize(Ssd), Encoding.UTF8, "application/json");
				resp = await client.GetAsync($"http://localhost:5000/api/SSD/{int.Parse(id.Text)}");
				response.Text = await resp.Content.ReadAsStringAsync();
				response.Text.Replace(' ', '\n');
				break;

			default: break;
		}
	}

	private void textBox2_TextChanged(object sender, EventArgs e)
	{

	}
}