# Local SPT 5.0 shared-library port

Fork of danx91/SPT-ZGFueDkxCommonLibrary at 5901c6e78a3116befb3215f371a79b8341b623be, maintained on spt-5.0-eft-1.3.0.0.48484 for the AllQuestsCheckmarks port. This source is compiled into the client mod; it is not a separately installed plugin.

Changes: managed Newtonsoft.Json converter for the native EFT.MongoID reference wrapper; BepInEx TOML converter registration for generated UnityEngine.Color, preserving RGBA as hexadecimal. Both address runtime compatibility gaps in the IL2CPP environment.

Build and test through AllQuestsCheckmarks (Shared submodule). Its tests/RuntimeChecks.csproj exercises actual quest JSON/native MongoID equality and Color serialization inside the target game. Keep that integration harness in the consuming repo because it requires its server endpoint and plugin setup.
