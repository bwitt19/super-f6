# super-f6
An open-source Unity system for data visualization of different satellites and celestial bodies.  
Based on [CFA (Cluster Flight Application)](https://www.emergentspace.com/products/cluster-flight-application/) from [Emergent Space](https://www.emergentspace.com/), used with DARPA's System F6.

This project is currently in **very very early** development stages, and should see a 0.x release around late-December 2019.

### Proposed functionality:

* Unity-based method of visualizing sets of celestial bodies, and the orbits they follow
* Ability to highlight and view specific celestial bodies and satellites by ID
* _(Future)_ Ability to control viewpoint and move about in the space
* _(Future)_ Capability of viewing the scene and navigating with a VR headset

### Current timeline:

* Currently working on a very simple beta release of a simple Unity implementation for viewing a set of sample celestial bodies
* Shooting for 12/2019 for a 0.x release for running on general systems
* Will be implementing the barebones ability to interact with which satellites are focused on at a given moment, and navigate about the environment
* For a 1.0 release over the Spring 2020 semester, will be working on a VR implementation using the SteamVR library with Unity

### How to use/run:
Finished version releases will be stored in the _Releases_ tab of this repository, and the code shown in the repository itself is the raw Unity environment code & scene information.

Working builds can be found in _master_, alongside other branches with ongoing feature development.

This build currently uses Unity version 2019.2.11 -- ensure you have this version when attempting to open and use the raw scene data/environment code.

---

Built for UMBC's Fall 2019 CMSC 436/636 Data Visualization course, taught by Dr. Don Engel.

If you're looking at this, you might also find this cool: [NASA's GMAT (General Mission Analysis Tool)](https://software.nasa.gov/software/GSC-17177-1) for trajectory optimization, mission analysis, trajectory estimation, and prediction.
