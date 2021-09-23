# Swate Installer

As long as [Swate](https://github.com/nfdi4plants/Swate) will not be available from the Microsoft Store, this installer can be used. It aims to provide an easier solution then previous alternatives.

If you have any problems using this, please let us know [here](https://github.com/omaus/Swate_Install/issues/new).

## How to use it

1. Download the newest version of the Swate Installer for your respective OS:
   - [Windows (64-bit)](https://github.com/omaus/Swate_Install/raw/master/Installer/Win/Install.exe)
   - [Linux (64-bit)](https://github.com/omaus/Swate_Install/raw/master/Installer/Linux/Install)
   - [MacOS (64-bit)](https://github.com/omaus/Swate_Install/raw/master/Installer/OSx/Install)
2. Run the **install** application (in case of Windows: **install.exe**). This will download necessary files and register Swate for your Microsoft Excel application.
3. Open/Restart Excel ➔ Insert ➔ Click on the small arrow on the right side of My Add-ins ➔ Swate (Under Developer Add-ins).  
![install](/.assets/SwateInstall.png)
4. You will be able to access Swate like this with all Excel instances.
6. Deleting the config folder from the Swate folder will crash Swate. In that case you can simply run the **install** file again.

## Uninstall

If you want to cleanly remove Swate from MS Excel, use the provided Uninstaller for your respective OS.  
Swate Installer already downloads the fitting file for you into the folder where the executable _Install_ file is. If you missed or accidentally deleted the file you can download it here:
1. Right click on the links and choose "Save link as..."/"Save target as..."
    - [Windows](https://raw.githubusercontent.com/omaus/Swate_Install/master/uninstall.cmd)
    - [Linux/MacOS](https://raw.githubusercontent.com/omaus/Swate_Install/master/uninstall.sh)
2. Place it into the folder where you installed Swate.
3. Run it.

## Overview

![overview](/.assets/Overview.jpg)

## References

The Swate installer uses the sideload functionality from the [WebAddinSideloader](https://github.com/davecra/WebAddinSideloader).
