//Maya ASCII 2019 scene
//Name: New_Enemy.ma
//Last modified: Wed, Mar 09, 2022 07:58:48 AM
//Codeset: 1252
requires maya "2019";
currentUnit -l centimeter -a degree -t film;
fileInfo "application" "maya";
fileInfo "product" "Maya 2019";
fileInfo "version" "2019";
fileInfo "cutIdentifier" "201812112215-434d8d9c04";
fileInfo "osv" "Microsoft Windows 10 Technical Preview  (Build 19044)\n";
createNode transform -s -n "persp";
	rename -uid "E86EE203-4E2C-E177-3768-229302C4A868";
	setAttr ".v" no;
	setAttr ".t" -type "double3" -5.1199276863784497 23.888171518223015 -72.279117629892426 ;
	setAttr ".r" -type "double3" -6.3383527293104605 -1254.999999998842 0 ;
createNode camera -s -n "perspShape" -p "persp";
	rename -uid "B9CF5732-479A-1B97-7007-25A0D39DD27A";
	setAttr -k off ".v" no;
	setAttr ".fl" 34.999999999999993;
	setAttr ".coi" 51.364728813161641;
	setAttr ".imn" -type "string" "persp";
	setAttr ".den" -type "string" "persp_depth";
	setAttr ".man" -type "string" "persp_mask";
	setAttr ".tp" -type "double3" -9.8009910937068305 32.969384553548082 -0.31062228753359611 ;
	setAttr ".hc" -type "string" "viewSet -p %camera";
createNode transform -s -n "top";
	rename -uid "99E2C832-44FE-FC2B-E6EE-EFBC0329D15A";
	setAttr ".v" no;
	setAttr ".t" -type "double3" 2.8880298514183638 1000.1001842942208 0.036451350397411653 ;
	setAttr ".r" -type "double3" -90 0 0 ;
createNode camera -s -n "topShape" -p "top";
	rename -uid "A3FC97A5-4DA4-AF67-0CE2-3B87FA1C6C5D";
	setAttr -k off ".v" no;
	setAttr ".rnd" no;
	setAttr ".coi" 998.38881974440312;
	setAttr ".ow" 16.96693352888888;
	setAttr ".imn" -type "string" "top";
	setAttr ".den" -type "string" "top_depth";
	setAttr ".man" -type "string" "top_mask";
	setAttr ".tp" -type "double3" 0.5 1.7113645498176027 -0.5 ;
	setAttr ".hc" -type "string" "viewSet -t %camera";
	setAttr ".o" yes;
createNode transform -s -n "front";
	rename -uid "49264BAF-40EC-5C9A-9802-0F89D80E9CC6";
	setAttr ".v" no;
	setAttr ".t" -type "double3" 8.3517206557654511 24.760993793216745 1000.1015884299917 ;
createNode camera -s -n "frontShape" -p "front";
	rename -uid "A1931FE1-4AAF-EF13-1650-8FA910B8272D";
	setAttr -k off ".v" no;
	setAttr ".rnd" no;
	setAttr ".coi" 1000.6015884299917;
	setAttr ".ow" 119.81646300822342;
	setAttr ".imn" -type "string" "front";
	setAttr ".den" -type "string" "front_depth";
	setAttr ".man" -type "string" "front_mask";
	setAttr ".tp" -type "double3" 0.5 1.7113645498176027 -0.5 ;
	setAttr ".hc" -type "string" "viewSet -f %camera";
	setAttr ".o" yes;
createNode transform -s -n "side";
	rename -uid "8CB7905D-4018-F965-ABA0-93A8560D4828";
	setAttr ".v" no;
	setAttr ".t" -type "double3" 1000.1015900190547 26.815408372045724 -6.2550167551461033 ;
	setAttr ".r" -type "double3" 0 90 0 ;
createNode camera -s -n "sideShape" -p "side";
	rename -uid "4F40C61A-438F-44D2-6D17-9495E10CDF67";
	setAttr -k off ".v" no;
	setAttr ".rnd" no;
	setAttr ".coi" 999.6015900190547;
	setAttr ".ow" 103.83214377692491;
	setAttr ".imn" -type "string" "side";
	setAttr ".den" -type "string" "side_depth";
	setAttr ".man" -type "string" "side_mask";
	setAttr ".tp" -type "double3" 0.5 1.7113645498176027 -0.5 ;
	setAttr ".hc" -type "string" "viewSet -s %camera";
	setAttr ".o" yes;
createNode transform -n "Body";
	rename -uid "2B0DE3FC-43DB-0B86-5720-8CB3621D51CA";
createNode transform -n "Head" -p "Body";
	rename -uid "63BF7F28-46F6-9BC4-33B2-C589AD2C6698";
	setAttr ".t" -type "double3" 0 26.805224616719503 0 ;
	setAttr ".s" -type "double3" 2.1616465643465208 1.9853770444337757 2.2888356010672144 ;
createNode mesh -n "HeadShape" -p "Head";
	rename -uid "E9901DA4-4117-C4DE-2D46-0793A2A6EB25";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
createNode transform -n "OG_Body" -p "Body";
	rename -uid "38D84390-4ADB-469A-2B92-7C800B1C66EB";
	setAttr ".t" -type "double3" 0 19.450766957911799 0 ;
	setAttr ".s" -type "double3" -8.2134785282229714 20.352554590641802 5.0946844427557458 ;
createNode mesh -n "OG_BodyShape" -p "OG_Body";
	rename -uid "755A718B-485F-CC45-C2F3-6EA02A0CEE67";
	setAttr -k off ".v";
	setAttr -s 2 ".iog";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".pv" -type "double2" 0.87499997019767761 0.18497385084629059 ;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 102 ".pt";
	setAttr ".pt[9]" -type "float3" 0 -2.3283064e-10 0 ;
	setAttr ".pt[10]" -type "float3" 0 2.3283064e-10 0 ;
	setAttr ".pt[11]" -type "float3" 0 -0.023374757 2.9802322e-08 ;
	setAttr ".pt[14]" -type "float3" 0 -0.0032462608 0.015390633 ;
	setAttr ".pt[15]" -type "float3" 0 -0.015516982 0.016314382 ;
	setAttr ".pt[21]" -type "float3" 0 -0.015516982 0.016314382 ;
	setAttr ".pt[22]" -type "float3" 0 2.3283064e-10 0 ;
	setAttr ".pt[23]" -type "float3" 0 -0.0032462608 0.015390633 ;
	setAttr ".pt[24]" -type "float3" 0 -2.3283064e-10 0 ;
	setAttr ".pt[25]" -type "float3" 0 -0.023374757 2.9802322e-08 ;
	setAttr ".pt[27]" -type "float3" 0 -0.012159994 0.011557235 ;
	setAttr ".pt[29]" -type "float3" 0 -0.0028549808 0.013535574 ;
	setAttr ".pt[30]" -type "float3" 0 9.3132257e-10 0 ;
	setAttr ".pt[31]" -type "float3" 0 -0.022420418 1.4901161e-08 ;
	setAttr ".pt[32]" -type "float3" 0 -9.3132257e-10 0 ;
	setAttr ".pt[33]" -type "float3" 0 -0.0418985 0.052046515 ;
	setAttr ".pt[34]" -type "float3" 0 -2.0008883e-09 0 ;
	setAttr ".pt[35]" -type "float3" 0 -0.010174263 0.040359419 ;
	setAttr ".pt[36]" -type "float3" 0 -2.5029294e-09 0 ;
	setAttr ".pt[37]" -type "float3" 0 -0.055411343 0.0097802505 ;
	setAttr ".pt[38]" -type "float3" 0 -8.1490725e-10 0 ;
	setAttr ".pt[39]" -type "float3" 0 0.12414698 -0.67180192 ;
	setAttr ".pt[40]" -type "float3" 0 0.091207676 -0.82437682 ;
	setAttr ".pt[41]" -type "float3" 0 0.12189487 -0.6611715 ;
	setAttr ".pt[42]" -type "float3" 0 0.088970087 -0.8136822 ;
	setAttr ".pt[43]" -type "float3" 0 0.054323759 -0.99010491 ;
	setAttr ".pt[44]" -type "float3" 0 0.052071963 -0.9794749 ;
	setAttr ".pt[49]" -type "float3" 0 -2.3283064e-10 0 ;
	setAttr ".pt[51]" -type "float3" 0 -5.8207661e-11 0 ;
	setAttr ".pt[53]" -type "float3" 0 -2.3283064e-10 0 ;
	setAttr ".pt[54]" -type "float3" 0 2.3283064e-10 0 ;
	setAttr ".pt[55]" -type "float3" 0 -0.023374757 2.9802322e-08 ;
	setAttr ".pt[57]" -type "float3" 0 -0.015516982 0.016314382 ;
	setAttr ".pt[58]" -type "float3" 0 -0.0032462608 0.015390633 ;
	setAttr ".pt[61]" -type "float3" 0 -0.023374753 2.9802322e-08 ;
	setAttr ".pt[65]" -type "float3" 0 0.11535288 -0.71101415 ;
	setAttr ".pt[66]" -type "float3" 0 0.090918325 -0.82305461 ;
	setAttr ".pt[67]" -type "float3" 0 0.11359543 -0.70272028 ;
	setAttr ".pt[68]" -type "float3" 0 0.089139216 -0.81574851 ;
	setAttr ".pt[69]" -type "float3" 0 0.062838793 -0.94958061 ;
	setAttr ".pt[70]" -type "float3" 0 0.061088283 -0.94131398 ;
	setAttr ".pt[71]" -type "float3" 0 0.13583571 -0.80641544 ;
	setAttr ".pt[72]" -type "float3" 0 0.11098149 -0.91769177 ;
	setAttr ".pt[73]" -type "float3" 0 0.13407794 -0.79812181 ;
	setAttr ".pt[74]" -type "float3" 0 0.10920189 -0.91038549 ;
	setAttr ".pt[75]" -type "float3" 0 0.082769267 -1.0448134 ;
	setAttr ".pt[76]" -type "float3" 0 0.081018798 -1.0365477 ;
	setAttr ".pt[77]" -type "float3" 0 0.15347242 -0.91526413 ;
	setAttr ".pt[78]" -type "float3" 0 0.13139728 -1.0140094 ;
	setAttr ".pt[79]" -type "float3" 0 0.15007821 -0.89935851 ;
	setAttr ".pt[80]" -type "float3" 0 0.12770325 -0.99807513 ;
	setAttr ".pt[81]" -type "float3" 0 0.10597069 -1.1286018 ;
	setAttr ".pt[82]" -type "float3" 0 0.10261423 -1.1126523 ;
	setAttr ".pt[83]" -type "float3" 0 0.1043158 -1.1207376 ;
	setAttr ".pt[84]" -type "float3" 0 0.10429237 -1.1206268 ;
	setAttr ".pt[85]" -type "float3" 0 0.12976545 -1.0069712 ;
	setAttr ".pt[86]" -type "float3" 0 0.15173036 -0.90709919 ;
	setAttr ".pt[87]" -type "float3" 0 0.13120925 -1.0131072 ;
	setAttr ".pt[88]" -type "float3" 0 0.11163232 -1.1015054 ;
	setAttr ".pt[89]" -type "float3" 0 0.13019881 -1.0067734 ;
	setAttr ".pt[90]" -type "float3" 0 0.11034176 -1.0953751 ;
	setAttr ".pt[91]" -type "float3" 0 0.14745051 -0.9406569 ;
	setAttr ".pt[92]" -type "float3" 0 0.14609221 -0.93429315 ;
	setAttr ".pt[93]" -type "float3" 0 0.12976545 -1.0069712 ;
	setAttr ".pt[94]" -type "float3" 0 0.15173018 -0.90709853 ;
	setAttr ".pt[95]" -type "float3" 0 0.15007821 -0.89935851 ;
	setAttr ".pt[96]" -type "float3" 0 0.12770325 -0.99807513 ;
	setAttr ".pt[97]" -type "float3" 0 0.1043158 -1.1207376 ;
	setAttr ".pt[98]" -type "float3" 0 0.10261423 -1.1126523 ;
	setAttr ".pt[99]" -type "float3" 0 0.10429237 -1.1206268 ;
	setAttr ".pt[100]" -type "float3" 0 0.12954959 -1.007073 ;
	setAttr ".pt[101]" -type "float3" 0 0.14874408 -0.91991186 ;
	setAttr ".pt[102]" -type "float3" 0 0.14723399 -0.91283566 ;
	setAttr ".pt[103]" -type "float3" 0 0.12773344 -0.99912471 ;
	setAttr ".pt[104]" -type "float3" 0 0.10715962 -1.1072543 ;
	setAttr ".pt[105]" -type "float3" 0 0.10561026 -1.0998908 ;
	setAttr ".pt[106]" -type "float3" 0 0.10723434 -1.1076077 ;
	setAttr ".pt[107]" -type "float3" 0 0.15556309 -1.129769 ;
	setAttr ".pt[108]" -type "float3" 0 0.17505148 -1.0409774 ;
	setAttr ".pt[109]" -type "float3" 0 0.21166569 -1.2093505 ;
	setAttr ".pt[110]" -type "float3" 0 0.20296596 -1.3538362 ;
	setAttr ".pt[111]" -type "float3" 0 0.13257796 -1.2299906 ;
	setAttr ".pt[112]" -type "float3" 0 0.16955736 -1.4086699 ;
	setAttr ".pt[113]" -type "float3" 0 0.13065383 -1.2206933 ;
	setAttr ".pt[114]" -type "float3" 0 0.17197934 -1.2055682 ;
	setAttr ".pt[115]" -type "float3" 0 0.15170565 -1.2910501 ;
	setAttr ".pt[116]" -type "float3" 0 0.14173609 -1.0612363 ;
	setAttr ".pt[117]" -type "float3" 0 0.12248487 -1.1528107 ;
	setAttr ".pt[118]" -type "float3" 0 0.18789892 -1.1312311 ;
	setAttr ".pt[119]" -type "float3" 0 0.15735632 -0.98736304 ;
	setAttr ".pt[134]" -type "float3" 0 -0.10623166 0.00080431724 ;
	setAttr ".pt[135]" -type "float3" 0 -0.10606201 0 ;
	setAttr ".pt[136]" -type "float3" 0 -0.079640277 0.054080267 ;
	setAttr ".pt[137]" -type "float3" 0 -0.037770923 0.11912452 ;
	setAttr ".pt[138]" -type "float3" 0 -0.043454446 0.11912452 ;
	setAttr ".pt[139]" -type "float3" 0 -0.083235212 0.058971446 ;
createNode transform -n "OG_half" -p "Body";
	rename -uid "7BD664F8-4712-32A8-A6A4-AEAC4852B67C";
	setAttr ".t" -type "double3" -0.25583741113626246 19.450766957911799 0 ;
	setAttr ".s" -type "double3" 8.2134785282229714 20.352554590641802 5.0946844427557458 ;
parent -s -nc -r -add "|Body|OG_Body|OG_BodyShape" "OG_half" ;
createNode lightLinker -s -n "lightLinker1";
	rename -uid "994D1C9F-4497-9A78-5390-2CAC5E491CDC";
	setAttr -s 2 ".lnk";
	setAttr -s 2 ".slnk";
createNode shapeEditorManager -n "shapeEditorManager";
	rename -uid "587166C2-4BC1-326F-9480-5DBF6668C283";
createNode poseInterpolatorManager -n "poseInterpolatorManager";
	rename -uid "003B1BF2-473C-8D56-D88B-6EAE2BFB25B7";
createNode displayLayerManager -n "layerManager";
	rename -uid "4D10422C-4A16-687F-77B0-ED96DEDC04EA";
createNode displayLayer -n "defaultLayer";
	rename -uid "460E6C58-48C6-9606-727B-159DAA1FBA6D";
createNode renderLayerManager -n "renderLayerManager";
	rename -uid "6C2028E3-46CD-5BCE-0BED-26BEA95090EE";
createNode renderLayer -n "defaultRenderLayer";
	rename -uid "06E467A7-43F6-9756-71E1-32A23794685A";
	setAttr ".g" yes;
createNode polyCube -n "polyCube1";
	rename -uid "55FE020E-484B-E55B-AC7C-B79E5B1466D8";
	setAttr ".cuv" 4;
createNode polySplitRing -n "polySplitRing1";
	rename -uid "C03F064D-4704-F863-A816-FDB6D253BFBA";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 2 "e[6:7]" "e[10:11]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 2.3971216800506103 0 0 0 0 1 0 0 1.7113645498176027 0 1;
	setAttr ".wt" 0.51690530776977539;
	setAttr ".re" 6;
	setAttr ".sma" 29.999999999999996;
	setAttr ".p[0]"  0 0 1;
	setAttr ".fq" yes;
createNode polySplitRing -n "polySplitRing2";
	rename -uid "865ECCEA-49F2-D3CF-0FB7-52928A2CFC5C";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 3 "e[0:3]" "e[16]" "e[19]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 2.3971216800506103 0 0 0 0 1 0 0 1.7113645498176027 0 1;
	setAttr ".wt" 0.50519061088562012;
	setAttr ".re" 1;
	setAttr ".sma" 29.999999999999996;
	setAttr ".p[0]"  0 0 1;
	setAttr ".fq" yes;
createNode polySplitRing -n "polySplitRing3";
	rename -uid "97219E88-4944-29E5-656D-6F8169B3B4DE";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 6 "e[4:5]" "e[8:9]" "e[14]" "e[18]" "e[26]" "e[31]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 2.3971216800506103 0 0 0 0 1 0 0 1.7113645498176027 0 1;
	setAttr ".wt" 0.90907853841781616;
	setAttr ".dr" no;
	setAttr ".re" 5;
	setAttr ".sma" 29.999999999999996;
	setAttr ".p[0]"  0 0 1;
	setAttr ".fq" yes;
createNode polySplitRing -n "polySplitRing4";
	rename -uid "D46E38C8-4AF7-5D54-4118-BC8C42EFB2CC";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 7 "e[4:5]" "e[18]" "e[31]" "e[37]" "e[39]" "e[41]" "e[43]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 2.3971216800506103 0 0 0 0 1 0 0 1.7113645498176027 0 1;
	setAttr ".wt" 0.81389600038528442;
	setAttr ".dr" no;
	setAttr ".re" 5;
	setAttr ".sma" 29.999999999999996;
	setAttr ".p[0]"  0 0 1;
	setAttr ".fq" yes;
createNode polySplitRing -n "polySplitRing5";
	rename -uid "AE433A7E-456C-92D1-006F-4395FC08266A";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 7 "e[4:5]" "e[18]" "e[31]" "e[53]" "e[55]" "e[57]" "e[59]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 2.3971216800506103 0 0 0 0 1 0 0 1.7113645498176027 0 1;
	setAttr ".wt" 0.51560771465301514;
	setAttr ".re" 5;
	setAttr ".sma" 29.999999999999996;
	setAttr ".p[0]"  0 0 1;
	setAttr ".fq" yes;
createNode polyExtrudeFace -n "polyExtrudeFace1";
	rename -uid "19DC5791-445D-0044-C091-7698AE81FAB7";
	setAttr ".ics" -type "componentList" 1 "f[30:31]";
	setAttr ".ix" -type "matrix" 0.88849827045990426 0 0 0 0 2.3971216800506103 0 0 0 0 0.52049532995544301 0
		 0 1.7113645498176027 0 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 0.44424912 2.4891992 0 ;
	setAttr ".rs" 44470;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" 0.44424913522995213 2.2864229507768687 -0.2602476649777215 ;
	setAttr ".cbx" -type "double3" 0.44424913522995213 2.6919755831023662 0.2602476649777215 ;
createNode polyExtrudeFace -n "polyExtrudeFace2";
	rename -uid "95DDA4B3-4DB8-88F2-CF80-259BE49E0A15";
	setAttr ".ics" -type "componentList" 1 "f[30:31]";
	setAttr ".ix" -type "matrix" 0.88849827045990426 0 0 0 0 2.3971216800506103 0 0 0 0 0.52049532995544301 0
		 0 1.7113645498176027 0 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 0.44424912 2.4891994 0 ;
	setAttr ".rs" 56343;
	setAttr ".lt" -type "double3" 0 0 0.15 ;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" 0.44424913522995213 2.2864230222166619 -0.2602476649777215 ;
	setAttr ".cbx" -type "double3" 0.44424913522995213 2.6919757259819526 0.2602476649777215 ;
createNode polyExtrudeFace -n "polyExtrudeFace3";
	rename -uid "09F85492-45B0-B7CA-644A-1A9BC3CA4FD6";
	setAttr ".ics" -type "componentList" 1 "f[26:27]";
	setAttr ".ix" -type "matrix" 0.88849827045990426 0 0 0 0 2.3971216800506103 0 0 0 0 0.52049532995544301 0
		 0 1.7113645498176027 0 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" -0.44424912 2.4891994 0 ;
	setAttr ".rs" 53542;
	setAttr ".lt" -type "double3" 0 0 0.15 ;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -0.44424913522995213 2.2864230222166619 -0.2602476649777215 ;
	setAttr ".cbx" -type "double3" -0.44424913522995213 2.6919757259819526 0.2602476649777215 ;
createNode polyExtrudeFace -n "polyExtrudeFace4";
	rename -uid "C916B603-45E8-60D9-C4F8-918EC8B5EEC0";
	setAttr ".ics" -type "componentList" 1 "f[30:31]";
	setAttr ".ix" -type "matrix" 0.88849827045990426 0 0 0 0 2.3971216800506103 0 0 0 0 0.52049532995544301 0
		 0 1.7113645498176027 0 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 0.59424913 2.4891994 0 ;
	setAttr ".rs" 35293;
	setAttr ".lt" -type "double3" 0 0 0.3 ;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" 0.59424914126496009 2.2864230222166619 -0.2602476649777215 ;
	setAttr ".cbx" -type "double3" 0.59424914126496009 2.6919757259819526 0.2602476649777215 ;
createNode polyExtrudeFace -n "polyExtrudeFace5";
	rename -uid "D18D17E7-45E4-D571-DC6E-2D8F49A3DCF7";
	setAttr ".ics" -type "componentList" 1 "f[26:27]";
	setAttr ".ix" -type "matrix" 0.88849827045990426 0 0 0 0 2.3971216800506103 0 0 0 0 0.52049532995544301 0
		 0 1.7113645498176027 0 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" -0.59424913 2.4891994 0 ;
	setAttr ".rs" 33860;
	setAttr ".lt" -type "double3" 0 0 0.3 ;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -0.59424914126496009 2.2864230222166619 -0.2602476649777215 ;
	setAttr ".cbx" -type "double3" -0.59424914126496009 2.6919757259819526 0.2602476649777215 ;
createNode polyExtrudeFace -n "polyExtrudeFace6";
	rename -uid "A4D840F9-4E8A-7417-8E8E-F0B6FFC2A636";
	setAttr ".ics" -type "componentList" 2 "f[64]" "f[67]";
	setAttr ".ix" -type "matrix" 0.88849827045990426 0 0 0 0 2.3971216800506103 0 0 0 0 0.52049532995544301 0
		 0 1.7113645498176027 0 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" -0.74424917 2.286423 0 ;
	setAttr ".rs" 46684;
	setAttr ".lt" -type "double3" 0 0 0.6 ;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -0.89424915333497612 2.2864230222166619 -0.2602476649777215 ;
	setAttr ".cbx" -type "double3" -0.59424914126496009 2.2864230222166619 0.2602476649777215 ;
createNode polyExtrudeFace -n "polyExtrudeFace7";
	rename -uid "E88D2D6F-4B64-26C4-161A-D1A1801E486B";
	setAttr ".ics" -type "componentList" 2 "f[58]" "f[61]";
	setAttr ".ix" -type "matrix" 0.88849827045990426 0 0 0 0 2.3971216800506103 0 0 0 0 0.52049532995544301 0
		 0 1.7113645498176027 0 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 0.74424917 2.286423 0 ;
	setAttr ".rs" 51399;
	setAttr ".lt" -type "double3" 0 0 0.6 ;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" 0.59424914126496009 2.2864230222166619 -0.2602476649777215 ;
	setAttr ".cbx" -type "double3" 0.89424915333497612 2.2864230222166619 0.2602476649777215 ;
createNode polyTweak -n "polyTweak1";
	rename -uid "F2DB7392-4C5F-DFAA-1F78-A4A14C023BB9";
	setAttr ".uopa" yes;
	setAttr -s 84 ".tk[0:83]" -type "float3"  0 -0.11906717 0 0 -0.11906717
		 0 0 0.0053848326 0 0 0.0053848326 0 0 0.0053848326 0 0 0.0053848326 0 0 -0.11906717
		 0 0 -0.11906717 0 0 0.0053848326 0 0 -0.11906717 0 0 -0.11906717 0 0 0.0053848326
		 0 0 0.00063319504 0 0 0.00063319504 0 0 0.00063319504 0 0 -0.11517801 0 0 -0.11517801
		 0 0 -0.11517801 0 0 -0.02033709 0 0 -0.024282783 0 0 -0.02033709 0 0 -0.02033709
		 0 0 -0.02033709 0 0 -0.024282783 0 0 -0.02033709 0 0 -0.02033709 0 0 -0.06461665
		 0 0 -0.066961944 0 0 -0.06461665 0 0 -0.06461665 0 0 -0.06461665 0 0 -0.066961944
		 0 0 -0.06461665 0 0 -0.06461665 0 0 -0.25770548 0 0 -0.25568581 0 0 -0.25770548 0
		 0 -0.25770548 0 0 -0.25770548 0 0 -0.25568581 0 0 -0.25770548 0 0 -0.25770548 0 0
		 -0.06461665 0 0 -0.02033709 0 0 -0.06461665 0 0 -0.02033709 0 0 -0.06461665 0 0 -0.02033709
		 0 0 -0.064003944 0 0 -0.019591764 0 0 -0.064003944 0 0 -0.019591764 0 0 -0.064003944
		 0 0 -0.019591764 0 0 -0.064003944 0 0 -0.064003944 0 0 -0.019591764 0 0 -0.019591764
		 0 0 -0.064003944 0 0 -0.019591764 0 0 -0.060391471 0 0 -0.015757769 0 0 -0.060391471
		 0 0 -0.015757769 0 0 -0.060391471 0 0 -0.015757769 0 0 -0.060391471 0 0 -0.060391471
		 0 0 -0.015757769 0 0 -0.015757769 0 0 -0.060391471 0 0 -0.015757769 0 0 -0.11018008
		 0 0 -0.11018008 0 0 -0.10745384 0 0 -0.10745384 0 0 -0.11018008 0 0 -0.10745384 0
		 0 -0.11018008 0 0 -0.11018008 0 0 -0.10745384 0 0 -0.10745384 0 0 -0.11018008 0 0
		 -0.10745384 0;
createNode deleteComponent -n "deleteComponent1";
	rename -uid "7912904E-4CA5-D566-A78C-47A9908FA930";
	setAttr ".dc" -type "componentList" 6 "f[0]" "f[2]" "f[4:6]" "f[8]" "f[12]" "f[15]";
createNode deleteComponent -n "deleteComponent2";
	rename -uid "C6B9EA2F-4825-8972-078F-E6AA330CF24C";
	setAttr ".dc" -type "componentList" 2 "f[1:2]" "f[6:7]";
createNode polyCloseBorder -n "polyCloseBorder1";
	rename -uid "F868CBFB-4BD5-2741-88F6-7497052F00DA";
	setAttr ".ics" -type "componentList" 3 "e[48]" "e[50:54]" "e[56:57]";
createNode polySplit -n "polySplit1";
	rename -uid "90391171-4C84-175A-953E-DC93A1B50431";
	setAttr -s 2 ".e[0:1]"  1 1;
	setAttr -s 2 ".d[0:1]"  -2147483595 -2147483600;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polyExtrudeFace -n "polyExtrudeFace8";
	rename -uid "910AF826-4F0A-7D04-1AC6-519980ED6A96";
	setAttr ".ics" -type "componentList" 1 "f[70]";
	setAttr ".ix" -type "matrix" 0.88849827045990426 0 0 0 0 2.3971216800506103 0 0 0 0 0.52049532995544301 0
		 0 2.2653938525673416 0 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" -0.21981864 1.3659941 0 ;
	setAttr ".rs" 44342;
	setAttr ".off" 0.05000000074505806;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -0.44424913522995213 1.3635734099061778 -0.2602476649777215 ;
	setAttr ".cbx" -type "double3" 0.0046118487945038264 1.3684148132455443 0.2602476649777215 ;
createNode polyExtrudeFace -n "polyExtrudeFace9";
	rename -uid "533A9095-48C9-DA8A-D5BD-F6AF243FB8A8";
	setAttr ".ics" -type "componentList" 1 "f[71]";
	setAttr ".ix" -type "matrix" 0.88849827045990426 0 0 0 0 2.3971216800506103 0 0 0 0 0.52049532995544301 0
		 0 2.2653938525673416 0 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 0.22443049 1.365994 0 ;
	setAttr ".rs" 56881;
	setAttr ".off" 0.05000000074505806;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" 0.0046118487945038264 1.3635733384663848 -0.2602476649777215 ;
	setAttr ".cbx" -type "double3" 0.44424913522995213 1.3684146703659583 0.2602476649777215 ;
createNode polyExtrudeFace -n "polyExtrudeFace10";
	rename -uid "AD04FDEB-47CE-896D-5143-0E94B34C6842";
	setAttr ".ics" -type "componentList" 1 "f[70]";
	setAttr ".ix" -type "matrix" 0.88849827045990426 0 0 0 0 2.3971216800506103 0 0 0 0 0.52049532995544301 0
		 0 2.2653938525673416 0 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" -0.21981864 1.3659937 0 ;
	setAttr ".rs" 47536;
	setAttr ".lt" -type "double3" -7.8062556418956319e-17 8.1876274985611356e-16 1.1929890523596154 ;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -0.3942520371161542 1.3641124231452033 -0.21024766958319394 ;
	setAttr ".cbx" -type "double3" -0.045385246009380133 1.3678751570483809 0.21024766958319394 ;
createNode polyExtrudeFace -n "polyExtrudeFace11";
	rename -uid "C3A6D3A9-4B3B-FA5D-A3D7-568D85674CC1";
	setAttr ".ics" -type "componentList" 1 "f[71]";
	setAttr ".ix" -type "matrix" 0.88849827045990426 0 0 0 0 2.3971216800506103 0 0 0 0 0.52049532995544301 0
		 0 2.2653938525673416 0 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 0.22443047 1.3659939 0 ;
	setAttr ".rs" 37195;
	setAttr ".lt" -type "double3" -4.3368086899420177e-17 0 1.1706334918547534 ;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" 0.054608821131570263 1.3641238535121012 -0.21024766958319394 ;
	setAttr ".cbx" -type "double3" 0.39425211655408987 1.3678638695610692 0.21024766958319394 ;
createNode polySplitEdge -n "polySplitEdge1";
	rename -uid "2CB0848D-4DD2-95CB-B3A3-D2996E9F6407";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 3 "e[26]" "e[29:31]" "e[44:45]";
createNode polyTweak -n "polyTweak2";
	rename -uid "19208B36-4154-E8D6-E058-0E945D5E2FE6";
	setAttr ".uopa" yes;
	setAttr -s 55 ".tk";
	setAttr ".tk[6]" -type "float3" 0 4.6566129e-10 0 ;
	setAttr ".tk[7]" -type "float3" 0 4.6566129e-10 0 ;
	setAttr ".tk[8]" -type "float3" 0 4.6566129e-10 0 ;
	setAttr ".tk[9]" -type "float3" 0 -3.7252903e-09 0 ;
	setAttr ".tk[15]" -type "float3" 0.0012280515 -3.7252903e-09 0.0029258688 ;
	setAttr ".tk[16]" -type "float3" 0 -3.7252903e-09 0 ;
	setAttr ".tk[17]" -type "float3" 0.025714641 0.023289911 -0.08651156 ;
	setAttr ".tk[19]" -type "float3" -0.016985381 0.023289911 0 ;
	setAttr ".tk[20]" -type "float3" -0.016985381 0.023289911 0 ;
	setAttr ".tk[21]" -type "float3" -0.016985381 0.023289911 0 ;
	setAttr ".tk[23]" -type "float3" 0.025714641 0.023289911 0.087009363 ;
	setAttr ".tk[24]" -type "float3" 0.018064966 0.023289911 0.00041276991 ;
	setAttr ".tk[33]" -type "float3" 0.018064966 0.023289911 0.00041276991 ;
	setAttr ".tk[34]" -type "float3" 0 -3.7252903e-09 0 ;
	setAttr ".tk[35]" -type "float3" 0.025714641 0.023289911 0.087009363 ;
	setAttr ".tk[36]" -type "float3" 0.0012280515 -3.7252903e-09 0.0029258688 ;
	setAttr ".tk[37]" -type "float3" 0.025714641 0.023289911 -0.08651156 ;
	setAttr ".tk[38]" -type "float3" 0 -3.7252903e-09 0 ;
	setAttr ".tk[39]" -type "float3" 0.038605884 0.038088173 0.0013965777 ;
	setAttr ".tk[40]" -type "float3" -0.0017838302 -0.0030150795 8.2198072e-05 ;
	setAttr ".tk[41]" -type "float3" 0.040726747 0.038088173 0.17122595 ;
	setAttr ".tk[42]" -type "float3" -0.004336901 -0.0030150795 0.036378797 ;
	setAttr ".tk[43]" -type "float3" 0.038625441 0.038088173 -0.16835707 ;
	setAttr ".tk[44]" -type "float3" -0.0067522591 -0.0030150795 -0.025503198 ;
	setAttr ".tk[45]" -type "float3" -0.037156902 0.038088173 0 ;
	setAttr ".tk[46]" -type "float3" -0.037156902 0.038088173 0 ;
	setAttr ".tk[47]" -type "float3" 0.0071098725 -0.0030736083 0 ;
	setAttr ".tk[48]" -type "float3" 0.0071098725 -0.0030736083 0 ;
	setAttr ".tk[49]" -type "float3" -0.037156902 0.038088173 0 ;
	setAttr ".tk[50]" -type "float3" 0.007109873 -0.0030736083 0 ;
	setAttr ".tk[51]" -type "float3" -0.017389257 0.0018849848 0.002446773 ;
	setAttr ".tk[52]" -type "float3" -0.12973884 -0.060960706 0.00052956335 ;
	setAttr ".tk[53]" -type "float3" -0.059927586 0.0018849848 0.21036538 ;
	setAttr ".tk[54]" -type "float3" -0.1459202 -0.060960706 0.097044475 ;
	setAttr ".tk[55]" -type "float3" -0.059170451 0.0018849848 -0.20947559 ;
	setAttr ".tk[56]" -type "float3" -0.1365539 -0.060960706 -0.092920505 ;
	setAttr ".tk[57]" -type "float3" -0.0027672423 0.0018849848 0 ;
	setAttr ".tk[58]" -type "float3" -0.0027672427 0.0018849848 0 ;
	setAttr ".tk[59]" -type "float3" 0.14375113 -0.062143877 0 ;
	setAttr ".tk[60]" -type "float3" 0.14375113 -0.062143877 0 ;
	setAttr ".tk[61]" -type "float3" -0.0027672427 0.0018849848 0 ;
	setAttr ".tk[62]" -type "float3" 0.14375113 -0.062143877 0 ;
	setAttr ".tk[69]" -type "float3" 0.045455445 0 0.33093438 ;
	setAttr ".tk[70]" -type "float3" 0.04399357 0 0.0090347221 ;
	setAttr ".tk[71]" -type "float3" -0.092735484 0 0.33093438 ;
	setAttr ".tk[72]" -type "float3" -0.061994977 0 0.0089654699 ;
	setAttr ".tk[73]" -type "float3" 0.045483246 0 -0.33004451 ;
	setAttr ".tk[74]" -type "float3" -0.092174798 0 -0.33004451 ;
createNode polySplitEdge -n "polySplitEdge2";
	rename -uid "ADCEF6D3-48A3-DE5C-A1E0-D7B1EFDDAE70";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 4 "e[26]" "e[29:31]" "e[44:45]" "e[185:190]";
createNode polySplitEdge -n "polySplitEdge3";
	rename -uid "95992E42-44EE-7E19-DBC4-219D791000C3";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 2 "e[33]" "e[46:48]";
createNode deleteComponent -n "deleteComponent3";
	rename -uid "B878EB2C-4B55-4B61-80D5-33A2B4473F50";
	setAttr ".dc" -type "componentList" 8 "f[0:1]" "f[5:8]" "f[13:16]" "f[21:24]" "f[40:45]" "f[52:63]" "f[72:76]" "f[82:86]";
createNode deleteComponent -n "deleteComponent4";
	rename -uid "B67D6134-4979-08DC-6CE0-729522A383B4";
	setAttr ".dc" -type "componentList" 1 "f[38]";
createNode polyMergeVert -n "polyMergeVert1";
	rename -uid "5984707D-49B3-26A9-CEA5-649681BD100E";
	setAttr ".ics" -type "componentList" 1 "vtx[3]";
	setAttr ".ix" -type "matrix" 12.688101706550521 0 0 0 0 34.231832171959176 0 0 0 0 7.4328762405365509 0
		 0 33.30108188061002 0 1;
	setAttr ".d" 1e-06;
createNode polyExtrudeFace -n "polyExtrudeFace12";
	rename -uid "80128B4D-496A-3D32-095C-35B330F93BAA";
	setAttr ".ics" -type "componentList" 2 "f[26]" "f[29]";
	setAttr ".ix" -type "matrix" 12.688101706550521 0 0 0 0 34.231832171959176 0 0 0 0 7.4328762405365509 0
		 -0.25583741113626246 33.30108188061002 0 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 8.2507811 29.219902 0.0049248207 ;
	setAttr ".rs" 40932;
	setAttr ".off" 0.30000001192092896;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" 6.9791151424242148 29.173239645127389 -1.1990023776613301 ;
	setAttr ".cbx" -type "double3" 9.5224474382426969 29.266564411984611 1.2088520191512335 ;
createNode polyTweak -n "polyTweak3";
	rename -uid "5A586DF7-4AC3-9BC6-B341-53953F099AE7";
	setAttr ".uopa" yes;
	setAttr -s 73 ".tk";
	setAttr ".tk[0]" -type "float3" -0.31613237 -0.044783831 -0.1098078 ;
	setAttr ".tk[1]" -type "float3" -0.31613237 -0.044783831 0.1098078 ;
	setAttr ".tk[2]" -type "float3" -0.16023383 -0.044783831 0.00068377651 ;
	setAttr ".tk[3]" -type "float3" -0.01705187 -0.044783831 0 ;
	setAttr ".tk[4]" -type "float3" -0.0046135541 -0.044783831 0 ;
	setAttr ".tk[5]" -type "float3" -0.0237666 -0.044783831 0 ;
	setAttr ".tk[6]" -type "float3" -0.088623002 0 -0.022626167 ;
	setAttr ".tk[7]" -type "float3" -0.0040544984 -0.0045675072 0 ;
	setAttr ".tk[8]" -type "float3" -0.050335355 -0.0045675072 0 ;
	setAttr ".tk[9]" -type "float3" -0.087973803 0 0.022603849 ;
	setAttr ".tk[10]" -type "float3" -0.08071582 -0.0025938491 0.0005448733 ;
	setAttr ".tk[11]" -type "float3" -0.06082071 0 -0.0094023934 ;
	setAttr ".tk[14]" -type "float3" -0.059729777 0 0.0094640832 ;
	setAttr ".tk[15]" -type "float3" -0.05964721 0 0.00049760379 ;
	setAttr ".tk[16]" -type "float3" -0.095632859 0 -0.092379659 ;
	setAttr ".tk[19]" -type "float3" -0.095098279 0 0.092379659 ;
	setAttr ".tk[20]" -type "float3" -0.035923701 0 0.00057322276 ;
	setAttr ".tk[21]" -type "float3" -0.05964721 0 0.00049760379 ;
	setAttr ".tk[22]" -type "float3" -0.08071582 -0.0025938491 0.0005448733 ;
	setAttr ".tk[23]" -type "float3" -0.059729777 0 0.0094640832 ;
	setAttr ".tk[24]" -type "float3" -0.087973803 0 0.022603849 ;
	setAttr ".tk[25]" -type "float3" -0.06082071 0 -0.0094023934 ;
	setAttr ".tk[26]" -type "float3" -0.088623002 0 -0.022626167 ;
	setAttr ".tk[27]" -type "float3" -0.14187646 0 0.00092702208 ;
	setAttr ".tk[28]" -type "float3" -0.1383256 0 0.00098546618 ;
	setAttr ".tk[29]" -type "float3" -0.14216213 0 0.014856396 ;
	setAttr ".tk[30]" -type "float3" -0.14192495 2.3283064e-10 0.02251705 ;
	setAttr ".tk[31]" -type "float3" -0.14187907 0 -0.014509111 ;
	setAttr ".tk[32]" -type "float3" -0.14181638 -2.3283064e-10 -0.022713516 ;
	setAttr ".tk[33]" -type "float3" -0.17982139 0 0.0008803251 ;
	setAttr ".tk[34]" -type "float3" -0.16468537 4.6566129e-10 0.00096557406 ;
	setAttr ".tk[35]" -type "float3" -0.17409047 0 0.013116058 ;
	setAttr ".tk[36]" -type "float3" -0.1625054 -4.6566129e-10 0.018154884 ;
	setAttr ".tk[37]" -type "float3" -0.17419253 -4.6566129e-10 -0.012680773 ;
	setAttr ".tk[38]" -type "float3" -0.16376722 -4.6566129e-10 -0.017863406 ;
	setAttr ".tk[39]" -type "float3" -0.14279918 -9.3132257e-10 0.0077549377 ;
	setAttr ".tk[40]" -type "float3" -0.14260225 9.3132257e-10 0.00058739126 ;
	setAttr ".tk[41]" -type "float3" -0.16967048 5.8207661e-11 0.0077549452 ;
	setAttr ".tk[42]" -type "float3" -0.17381193 0 0.00059047056 ;
	setAttr ".tk[43]" -type "float3" -0.14280289 0 -0.0073196632 ;
	setAttr ".tk[44]" -type "float3" -0.1697461 0 -0.0073196632 ;
	setAttr ".tk[45]" -type "float3" -7.6108161e-05 0 0 ;
	setAttr ".tk[46]" -type "float3" -0.00035673528 0 0 ;
	setAttr ".tk[47]" -type "float3" -0.087040856 0 0.067369297 ;
	setAttr ".tk[48]" -type "float3" -0.035985317 0 0.00052079698 ;
	setAttr ".tk[49]" -type "float3" -0.087579519 0 -0.067369297 ;
	setAttr ".tk[50]" -type "float3" 0.061663672 -0.00022709384 0.15259019 ;
	setAttr ".tk[51]" -type "float3" 0.061663672 -0.00022709384 -0.15259019 ;
	setAttr ".tk[52]" -type "float3" -0.061663661 0.00022709384 0.15259019 ;
	setAttr ".tk[53]" -type "float3" -0.061663661 0.00022709384 0.0063860924 ;
	setAttr ".tk[54]" -type "float3" -0.061663661 0.00022709384 -0.15259019 ;
	setAttr ".tk[55]" -type "float3" -0.06082071 0 -0.0094023934 ;
	setAttr ".tk[56]" -type "float3" -0.088623002 0 -0.022626167 ;
	setAttr ".tk[57]" -type "float3" -0.05964721 0 0.00049760379 ;
	setAttr ".tk[58]" -type "float3" -0.059729777 0 0.0094640832 ;
	setAttr ".tk[59]" -type "float3" -0.087973803 0 0.022603849 ;
	setAttr ".tk[60]" -type "float3" -0.08071582 -0.0025938491 0.0005448733 ;
	setAttr ".tk[61]" -type "float3" -0.06082071 0 -0.0094023934 ;
	setAttr ".tk[64]" -type "float3" -0.095632859 0 -0.092379659 ;
createNode polyExtrudeFace -n "polyExtrudeFace13";
	rename -uid "9233A4B0-4BBF-051E-7CEE-4C8CA2DA8B7B";
	setAttr ".ics" -type "componentList" 2 "f[26]" "f[29]";
	setAttr ".ix" -type "matrix" 12.688101706550521 0 0 0 0 34.231832171959176 0 0 0 0 7.4328762405365509 0
		 -0.25583741113626246 33.30108188061002 0 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 8.2451277 29.21965 0.00492399 ;
	setAttr ".rs" 51449;
	setAttr ".lt" -type "double3" 2.4864428695535699e-15 -2.5673907444456745e-16 0.83177607149262667 ;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" 7.2789110769762004 29.18323544811463 -0.89901218494900759 ;
	setAttr ".cbx" -type "double3" 9.2113445139842778 29.2560646360768 0.90886016506160583 ;
createNode polyExtrudeFace -n "polyExtrudeFace14";
	rename -uid "2ADB0276-423B-9681-90B4-1C9FAD50F98B";
	setAttr ".ics" -type "componentList" 2 "f[26]" "f[29]";
	setAttr ".ix" -type "matrix" 12.688101706550521 0 0 0 0 34.231832171959176 0 0 0 0 7.4328762405365509 0
		 -0.25583741113626246 33.30108188061002 0 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 8.2777843 28.388531 0.0046629878 ;
	setAttr ".rs" 39476;
	setAttr ".lt" -type "double3" 6.0897604472926354e-16 -2.6367796834847468e-16 0.80981091402188099 ;
	setAttr ".ls" -type "double3" 2.1283489793593304 1 1 ;
	setAttr ".off" 0.10000000149011612;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" 7.3115683192679048 28.352116769688056 -0.90381506059977856 ;
	setAttr ".cbx" -type "double3" 9.2440010000061879 28.424945957650227 0.91314103596317353 ;
createNode polySplit -n "polySplit2";
	rename -uid "FBF167A3-4B27-B053-51B3-AB9B5AC74B1D";
	setAttr -s 4 ".e[0:3]"  0.5 0.493027 0.44176301 0.51336199;
	setAttr -s 4 ".d[0:3]"  -2147483501 -2147483501 -2147483506 -2147483509;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polyExtrudeFace -n "polyExtrudeFace15";
	rename -uid "7066067E-4824-44E3-4348-55815F23A439";
	setAttr ".ics" -type "componentList" 1 "f[67:68]";
	setAttr ".ix" -type "matrix" 12.688101706550521 0 0 0 0 34.231832171959176 0 0 0 0 7.4328762405365509 0
		 -0.25583741113626246 33.30108188061002 0 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 7.2900901 27.542082 0.0043989671 ;
	setAttr ".rs" 51201;
	setAttr ".off" 0.20000000298023224;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" 6.4109667025908257 27.506113546907137 -0.80870453264815734 ;
	setAttr ".cbx" -type "double3" 8.1692138115837043 27.578049050095188 0.81750246692480766 ;
createNode polyExtrudeFace -n "polyExtrudeFace16";
	rename -uid "4903CF23-4090-ECD8-0FB7-6E8ED05F054A";
	setAttr ".ics" -type "componentList" 2 "f[26]" "f[29]";
	setAttr ".ix" -type "matrix" 12.688101706550521 0 0 0 0 34.231832171959176 0 0 0 0 7.4328762405365509 0
		 -0.25583741113626246 33.30108188061002 0 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 9.2107124 27.613583 0.0044153319 ;
	setAttr ".rs" 61775;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" 8.1014747260372264 27.572739991231579 -0.80847919450636774 ;
	setAttr ".cbx" -type "double3" 10.319949818833933 27.65442645226328 0.81730985791592481 ;
createNode polyExtrudeFace -n "polyExtrudeFace17";
	rename -uid "149EA642-4A2E-962B-C27C-84936E2DB63C";
	setAttr ".ics" -type "componentList" 2 "f[26]" "f[29]";
	setAttr ".ix" -type "matrix" 12.688101706550521 0 0 0 0 34.231832171959176 0 0 0 0 7.4328762405365509 0
		 -0.25583741113626246 33.30108188061002 0 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 9.2107134 27.613583 0.0044153319 ;
	setAttr ".rs" 56466;
	setAttr ".off" 0.10000000149011612;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" 8.1014754823070216 27.572739991231579 -0.80847913912712432 ;
	setAttr ".cbx" -type "double3" 10.319950575103729 27.65442645226328 0.81730980253668128 ;
createNode polyExtrudeFace -n "polyExtrudeFace18";
	rename -uid "B4885426-4CC2-D46F-462F-7A99C5BB02AF";
	setAttr ".ics" -type "componentList" 2 "f[26]" "f[29]";
	setAttr ".ix" -type "matrix" 12.688101706550521 0 0 0 0 34.231832171959176 0 0 0 0 7.4328762405365509 0
		 -0.25583741113626246 33.30108188061002 0 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 9.1636257 27.61227 0.0044184052 ;
	setAttr ".rs" 38154;
	setAttr ".lt" -type "double3" 4.8256974723723603e-15 2.9837243786801082e-16 2 ;
	setAttr ".lr" -type "double3" 0 -91.935557056227523 0 ;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" 8.1250378240429377 27.575441449315907 -0.70847424901447487 ;
	setAttr ".cbx" -type "double3" 10.202213737133858 27.649101070390099 0.71731105952006002 ;
createNode polyExtrudeFace -n "polyExtrudeFace19";
	rename -uid "B0E20E00-429A-115A-340E-78A00B8E4BEB";
	setAttr ".ics" -type "componentList" 1 "f[67:68]";
	setAttr ".ix" -type "matrix" 12.688101706550521 0 0 0 0 34.231832171959176 0 0 0 0 7.4328762405365509 0
		 -0.25583741113626246 33.30108188061002 0 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 7.2858829 27.541641 0.0044002687 ;
	setAttr ".rs" 64665;
	setAttr ".lt" -type "double3" 0.3393188743471639 3.5691935518222806e-16 1.0945180544306912 ;
	setAttr ".lr" -type "double3" 0 106.27008564292305 0 ;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" 6.6109040171289397 27.513607848677324 -0.60867963388938373 ;
	setAttr ".cbx" -type "double3" 7.9608622393053849 27.569675346184258 0.61748017099047836 ;
createNode polyExtrudeFace -n "polyExtrudeFace20";
	rename -uid "DC9D3BAE-4D10-BC18-A17B-E5A6750AD34A";
	setAttr ".ics" -type "componentList" 1 "f[0:1]";
	setAttr ".ix" -type "matrix" 12.688101706550521 0 0 0 0 34.231832171959176 0 0 0 0 7.4328762405365509 0
		 -0.25583741113626246 33.30108188061002 0 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 1.7769527 41.816555 0 ;
	setAttr ".rs" 57061;
	setAttr ".off" 0.40000000596046448;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -0.49638837524565016 41.747678231164471 -3.7164359050985354 ;
	setAttr ".cbx" -type "double3" 4.0502939815717633 41.885430149326901 3.7164359050985354 ;
createNode polyTweak -n "polyTweak4";
	rename -uid "9E93802E-4722-EDAE-E1DF-E9A8EA99A31E";
	setAttr ".uopa" yes;
	setAttr -s 120 ".tk[0:119]" -type "float3"  -0.00038279407 -0.20982979
		 0 -0.00038279407 -0.20982979 0 -0.00038279407 -0.20982979 0 -0.00038279407 -0.20910245
		 0 -0.00038279407 -0.20910245 0 -0.00038279407 -0.20910245 0 -6.769679e-05 -0.19882989
		 0 -0.00022742874 -0.19752675 0 -0.00022511464 -0.19752675 0 -6.6303764e-05 -0.19882989
		 0 -0.0002054926 -0.19843285 0 0 -0.16971911 0 0 -0.165795 0 0 -0.165795 0 0 -0.16971911
		 0 0 -0.16971911 0 0 -0.081734665 0 0 -0.082043827 0 0 -0.082043827 0 0 -0.081734665
		 0 0 -0.081734665 0 0 -0.16971911 0 -0.0002054926 -0.19843285 0 0 -0.16971911 0 -6.6303764e-05
		 -0.19882989 0 0 -0.16971911 0 -6.769679e-05 -0.19882989 0 0 -0.17207813 0 -0.00010776869
		 -0.19848239 0 0 -0.17207813 0 -1.0555013e-05 -0.19848239 0 0 -0.17207813 0 -3.6992024e-06
		 -0.19848239 0 0 -0.16708927 0 0 -0.19019929 0 0 -0.16708927 0 0 -0.19019929 0 0 -0.16708927
		 0 0 -0.19019929 0 0 -0.12086453 0 -3.7252903e-09 -0.12086455 0 1.8626451e-09 -0.12128186
		 0 0 -0.12128187 0 0 -0.12086453 0 -1.8626451e-09 -0.12128186 0 0 -0.082008637 0 0
		 -0.082008637 0 0 -0.081769824 0 0 -0.081769824 0 0 -0.081769824 0 0 -0.078965217
		 0 0 -0.078965217 0 0 -0.07879594 0 0 -0.07879594 0 0 -0.07879594 0 0 -0.16971911
		 0 -6.769679e-05 -0.19882989 0 0 -0.16971911 0 0 -0.16971911 0 -6.6303764e-05 -0.19882989
		 0 -0.0002054926 -0.19843285 0 0 -0.16971911 0 0 -0.165795 0 0 -0.082043827 0 0 -0.081734665
		 0 3.7252903e-09 -0.12090924 0 0 -0.12091727 0 0 -0.12123492 0 0 -0.12122504 0 3.7252903e-09
		 -0.12091008 0 0 -0.12123454 0 0 -0.11719273 0 1.8626451e-09 -0.11720074 0 0 -0.11751838
		 0 0 -0.11750847 0 0 -0.11719353 0 1.8626451e-09 -0.117518 0 0 -0.11340963 0 0 -0.1134185
		 0 0 -0.11403622 0 0 -0.11407284 0 0 -0.11341159 0 1.8626451e-09 -0.11403568 0 -1.8626451e-09
		 -0.11371929 0 -1.8626451e-09 -0.11372364 0 -1.8626451e-09 -0.11370755 0 0 -0.11373129
		 0 0 -0.11345369 0 -1.8626451e-09 -0.11344497 0 1.8626451e-09 -0.11367236 0 0 -0.11368481
		 0 1.8626451e-09 -0.11344312 0 0 -0.11369384 0 0 -0.11370755 0 -2.3283064e-10 -0.11373128
		 0 0 -0.11403623 0 1.1641532e-10 -0.11407284 0 0 -0.11371929 0 0 -0.11403569 0 0 -0.11372364
		 0 0 -0.11372501 0 0 -0.11374345 0 0 -0.11402223 0 0 -0.11404901 0 0 -0.11373351 0
		 0 -0.11402164 0 0 -0.11371963 0 0 -0.10890637 0 0 -0.10893101 0 0 -0.10223571 0 0
		 -0.10011593 0 0 -0.10896784 0 0 -0.10203225 0 0 -0.1093287 0 0 -0.10589824 0 0 -0.10601116
		 0 0 -0.11153433 0 0 -0.11143228 0 0 -0.10595471 0 0 -0.11160852 0;
createNode polyExtrudeFace -n "polyExtrudeFace21";
	rename -uid "7DD4972F-4D92-3188-679F-16A46ED41DD2";
	setAttr ".ics" -type "componentList" 2 "f[0:1]" "f[104:105]";
	setAttr ".ix" -type "matrix" 12.688101706550521 0 0 0 0 34.231832171959176 0 0 0 0 7.4328762405365509 0
		 -0.25583741113626246 33.30108188061002 0 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 1.535241 41.808922 0 ;
	setAttr ".rs" 52006;
	setAttr ".lt" -type "double3" -2.3813649980446123 1.5994150448506161e-15 2.2359416503059695 ;
	setAttr ".lr" -type "double3" 0 2.5206013819627269 0 ;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -0.49638839887908126 41.747680271540666 -3.7164356835815617 ;
	setAttr ".cbx" -type "double3" 3.5668704468826387 41.870159973871395 3.7164356835815617 ;
createNode polySphere -n "polySphere1";
	rename -uid "13A03F4D-4AE1-51AE-3386-D1BF0D3AAF19";
createNode polyTweak -n "polyTweak5";
	rename -uid "92F337A6-470B-1529-A908-17B35040567F";
	setAttr ".uopa" yes;
	setAttr -s 114 ".tk";
	setAttr ".tk[0]" -type "float3" -0.021694364 0 -0.058147453 ;
	setAttr ".tk[1]" -type "float3" -0.016632594 0 0.056779418 ;
	setAttr ".tk[2]" -type "float3" -0.021152167 0 6.9007896e-05 ;
	setAttr ".tk[3]" -type "float3" 0.020185569 0 -0.16784975 ;
	setAttr ".tk[4]" -type "float3" -0.0011999648 0 0.0031767446 ;
	setAttr ".tk[5]" -type "float3" 0.031049427 0 0.1687417 ;
	setAttr ".tk[6]" -type "float3" 9.3132257e-10 0 0 ;
	setAttr ".tk[7]" -type "float3" -0.0063253976 0 0 ;
	setAttr ".tk[8]" -type "float3" 0.00071329233 0 0.0018219912 ;
	setAttr ".tk[9]" -type "float3" 9.3132257e-10 6.9849193e-10 0 ;
	setAttr ".tk[10]" -type "float3" -9.3132257e-10 4.6566129e-10 0 ;
	setAttr ".tk[11]" -type "float3" -1.1175871e-08 -4.6566129e-09 7.4505806e-09 ;
	setAttr ".tk[14]" -type "float3" 1.4901161e-08 2.3748726e-08 9.3132257e-10 ;
	setAttr ".tk[15]" -type "float3" -1.5017577e-08 4.1909516e-09 -1.8626451e-09 ;
	setAttr ".tk[21]" -type "float3" -1.5017577e-08 4.1909516e-09 -1.8626451e-09 ;
	setAttr ".tk[22]" -type "float3" -9.3132257e-10 4.6566129e-10 0 ;
	setAttr ".tk[23]" -type "float3" 1.4901161e-08 2.3748726e-08 9.3132257e-10 ;
	setAttr ".tk[24]" -type "float3" 9.3132257e-10 6.9849193e-10 0 ;
	setAttr ".tk[25]" -type "float3" -1.1175871e-08 -4.6566129e-09 7.4505806e-09 ;
	setAttr ".tk[26]" -type "float3" 9.3132257e-10 0 0 ;
	setAttr ".tk[27]" -type "float3" 9.3132257e-09 0 1.1175871e-08 ;
	setAttr ".tk[28]" -type "float3" 7.4505806e-09 -9.3132257e-10 0 ;
	setAttr ".tk[29]" -type "float3" 9.3132257e-09 -7.4505806e-09 -4.1909516e-09 ;
	setAttr ".tk[30]" -type "float3" 0 -1.8626451e-09 0 ;
	setAttr ".tk[31]" -type "float3" -5.5879354e-09 7.4505806e-09 -7.4505806e-09 ;
	setAttr ".tk[32]" -type "float3" -3.7252903e-09 1.8626451e-09 0 ;
	setAttr ".tk[33]" -type "float3" 0 2.2351742e-08 -2.9802322e-08 ;
	setAttr ".tk[34]" -type "float3" 0 -8.6147338e-09 -7.4505806e-09 ;
	setAttr ".tk[35]" -type "float3" 7.4505806e-09 7.4505806e-09 7.4505806e-09 ;
	setAttr ".tk[36]" -type "float3" 0 -4.8894435e-09 0 ;
	setAttr ".tk[37]" -type "float3" 2.9802322e-08 7.4505806e-09 1.4901161e-08 ;
	setAttr ".tk[38]" -type "float3" 0 -4.5401976e-09 3.7252903e-09 ;
	setAttr ".tk[39]" -type "float3" 1.7881393e-07 -4.4703484e-08 -2.2351742e-08 ;
	setAttr ".tk[40]" -type "float3" -1.1920929e-07 -1.4901161e-08 -1.6391277e-07 ;
	setAttr ".tk[41]" -type "float3" 2.3841858e-07 1.1920929e-07 2.3841858e-07 ;
	setAttr ".tk[42]" -type "float3" 2.3841858e-07 8.9406967e-08 -1.937151e-07 ;
	setAttr ".tk[43]" -type "float3" -5.9604645e-08 4.4703484e-08 1.1920929e-07 ;
	setAttr ".tk[44]" -type "float3" 5.9604645e-08 -2.9802322e-08 -4.4703484e-08 ;
	setAttr ".tk[55]" -type "float3" -1.1175871e-08 -4.6566129e-09 7.4505806e-09 ;
	setAttr ".tk[56]" -type "float3" 9.3132257e-10 0 0 ;
	setAttr ".tk[57]" -type "float3" -1.5017577e-08 4.1909516e-09 -1.8626451e-09 ;
	setAttr ".tk[58]" -type "float3" 1.4901161e-08 2.3748726e-08 9.3132257e-10 ;
	setAttr ".tk[59]" -type "float3" 9.3132257e-10 6.9849193e-10 0 ;
	setAttr ".tk[60]" -type "float3" -9.3132257e-10 4.6566129e-10 0 ;
	setAttr ".tk[61]" -type "float3" -1.1175871e-08 -4.6566129e-09 7.4505806e-09 ;
	setAttr ".tk[65]" -type "float3" 1.7881393e-07 7.4505806e-08 1.7136335e-07 ;
	setAttr ".tk[66]" -type "float3" 1.1920929e-07 7.4505806e-08 -1.1920929e-07 ;
	setAttr ".tk[67]" -type "float3" -5.9604645e-08 -8.9406967e-08 2.4586916e-07 ;
	setAttr ".tk[68]" -type "float3" 1.1920929e-07 -4.4703484e-08 -5.9604645e-07 ;
	setAttr ".tk[69]" -type "float3" 3.5762787e-07 2.9802322e-08 4.9173832e-07 ;
	setAttr ".tk[70]" -type "float3" -5.9604645e-08 2.9802322e-08 2.9802322e-08 ;
	setAttr ".tk[71]" -type "float3" 2.3841858e-07 -2.9802322e-08 -2.6077032e-07 ;
	setAttr ".tk[72]" -type "float3" 0 2.9802322e-08 -1.7881393e-07 ;
	setAttr ".tk[73]" -type "float3" 1.1920929e-07 0 4.3958426e-07 ;
	setAttr ".tk[74]" -type "float3" 5.9604645e-08 2.8312206e-07 2.7567148e-07 ;
	setAttr ".tk[75]" -type "float3" 1.7881393e-07 7.4505806e-08 1.3411045e-07 ;
	setAttr ".tk[76]" -type "float3" 2.3841858e-07 1.4901161e-08 -1.4156103e-07 ;
	setAttr ".tk[77]" -type "float3" 0 2.9802322e-08 8.251518e-07 ;
	setAttr ".tk[78]" -type "float3" 1.1920929e-07 1.6391277e-07 4.3585896e-07 ;
	setAttr ".tk[79]" -type "float3" -5.9604645e-08 7.4505806e-08 5.6996942e-07 ;
	setAttr ".tk[80]" -type "float3" 5.9604645e-08 4.4703484e-08 1.2665987e-07 ;
	setAttr ".tk[81]" -type "float3" 2.3841858e-07 1.4901161e-08 3.8743019e-07 ;
	setAttr ".tk[82]" -type "float3" 5.9604645e-08 5.9604645e-08 1.8253922e-07 ;
	setAttr ".tk[83]" -type "float3" 2.3841858e-07 1.1920929e-07 9.3132257e-08 ;
	setAttr ".tk[84]" -type "float3" -5.9604645e-08 2.0861626e-07 2.7194619e-07 ;
	setAttr ".tk[85]" -type "float3" 1.1920929e-07 4.4703484e-08 4.4330955e-07 ;
	setAttr ".tk[86]" -type "float3" 1.1920929e-07 -8.9406967e-08 1.3411045e-07 ;
	setAttr ".tk[87]" -type "float3" 1.7881393e-07 -1.0430813e-07 3.6880374e-07 ;
	setAttr ".tk[88]" -type "float3" 1.1920929e-07 -5.9604645e-08 -4.3213367e-07 ;
	setAttr ".tk[89]" -type "float3" 1.1920929e-07 1.4901161e-08 -3.7252903e-09 ;
	setAttr ".tk[90]" -type "float3" 4.1723251e-07 2.2351742e-07 4.6566129e-07 ;
	setAttr ".tk[91]" -type "float3" 5.9604645e-08 -8.9406967e-08 -5.7742e-08 ;
	setAttr ".tk[92]" -type "float3" 0 0 4.786998e-07 ;
	setAttr ".tk[93]" -type "float3" 1.1920929e-07 4.4703484e-08 4.4330955e-07 ;
	setAttr ".tk[94]" -type "float3" -5.9604645e-08 1.4901161e-08 1.1175871e-07 ;
	setAttr ".tk[95]" -type "float3" -5.9604645e-08 7.4505806e-08 5.6996942e-07 ;
	setAttr ".tk[96]" -type "float3" 5.9604645e-08 4.4703484e-08 1.2665987e-07 ;
	setAttr ".tk[97]" -type "float3" 2.3841858e-07 1.1920929e-07 9.3132257e-08 ;
	setAttr ".tk[98]" -type "float3" 5.9604645e-08 5.9604645e-08 1.8253922e-07 ;
	setAttr ".tk[99]" -type "float3" -5.9604645e-08 2.0861626e-07 2.7194619e-07 ;
	setAttr ".tk[100]" -type "float3" 0 0 3.3527613e-07 ;
	setAttr ".tk[101]" -type "float3" 5.9604645e-08 0 1.73226e-07 ;
	setAttr ".tk[102]" -type "float3" 5.9604645e-08 -2.9802322e-08 -9.4994903e-08 ;
	setAttr ".tk[103]" -type "float3" 5.9604645e-08 2.9802322e-08 3.5017729e-07 ;
	setAttr ".tk[104]" -type "float3" -5.9604645e-08 1.4901161e-08 6.6310167e-07 ;
	setAttr ".tk[105]" -type "float3" 2.3841858e-07 -4.4703484e-08 3.3900142e-07 ;
	setAttr ".tk[106]" -type "float3" 0 4.4703484e-08 1.4528632e-07 ;
	setAttr ".tk[107]" -type "float3" 1.7881393e-07 4.4703484e-08 1.5087426e-07 ;
	setAttr ".tk[108]" -type "float3" 5.9604645e-08 7.4505806e-08 1.7881393e-07 ;
	setAttr ".tk[109]" -type "float3" -2.9802322e-07 -4.4703484e-08 -1.4901161e-08 ;
	setAttr ".tk[110]" -type "float3" 1.1920929e-07 -4.4703484e-08 1.1920929e-07 ;
	setAttr ".tk[111]" -type "float3" 0 5.9604645e-08 3.3527613e-07 ;
	setAttr ".tk[112]" -type "float3" 1.1920929e-07 1.4901161e-08 1.6391277e-07 ;
	setAttr ".tk[113]" -type "float3" 1.1920929e-07 1.4901161e-07 3.1478703e-07 ;
	setAttr ".tk[114]" -type "float3" 5.9604645e-08 2.2351742e-07 -8.6426735e-07 ;
	setAttr ".tk[115]" -type "float3" -4.7683716e-07 1.4901161e-07 -2.3469329e-07 ;
	setAttr ".tk[116]" -type "float3" -1.7881393e-07 -7.4505806e-08 -2.7567148e-07 ;
	setAttr ".tk[117]" -type "float3" 0 -4.4703484e-08 1.3224781e-07 ;
	setAttr ".tk[118]" -type "float3" 1.7881393e-07 5.9604645e-08 4.2468309e-07 ;
	setAttr ".tk[119]" -type "float3" 3.5762787e-07 -1.1920929e-07 -3.5041012e-08 ;
	setAttr ".tk[120]" -type "float3" 0.010449639 0 -0.14114416 ;
	setAttr ".tk[121]" -type "float3" -0.025382556 0 -0.064766139 ;
	setAttr ".tk[122]" -type "float3" -0.028907454 0 0.00029014045 ;
	setAttr ".tk[123]" -type "float3" 0.02025857 0 0.14095736 ;
	setAttr ".tk[124]" -type "float3" -0.020176455 0 0.062469188 ;
	setAttr ".tk[125]" -type "float3" 0.11281095 0 -0.29085907 ;
	setAttr ".tk[126]" -type "float3" 0.050973706 0 -0.21939734 ;
	setAttr ".tk[127]" -type "float3" -0.038442496 0 0.0042617498 ;
	setAttr ".tk[128]" -type "float3" 0.071089067 0 0.0057083741 ;
	setAttr ".tk[129]" -type "float3" 0.11794453 0 0.2881563 ;
	setAttr ".tk[130]" -type "float3" 0.052372903 0 0.2152534 ;
	setAttr ".tk[131]" -type "float3" 0.12112003 0 -0.33131415 ;
	setAttr ".tk[132]" -type "float3" 0.080460206 0 0.0049242135 ;
	setAttr ".tk[133]" -type "float3" 0.12693021 0 0.32776007 ;
createNode deleteComponent -n "deleteComponent5";
	rename -uid "CAF4CB48-4772-EED5-A9EF-E785620A8C96";
	setAttr ".dc" -type "componentList" 4 "vtx[39:44]" "vtx[65:76]" "vtx[79:80]" "vtx[82:119]";
createNode polySplit -n "polySplit3";
	rename -uid "19501553-44F9-D087-8664-99895E68C7F8";
	setAttr -s 7 ".e[0:6]"  0.28542799 0.356208 0.355755 0.35586801 0.28131399
		 0.27926299 0.28542799;
	setAttr -s 7 ".d[0:6]"  -2147483571 -2147483573 -2147483579 -2147483580 -2147483577 -2147483575 
		-2147483571;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode script -n "uiConfigurationScriptNode";
	rename -uid "A801125A-4901-DA6C-A138-49BF2AF0B784";
	setAttr ".b" -type "string" (
		"// Maya Mel UI Configuration File.\n//\n//  This script is machine generated.  Edit at your own risk.\n//\n//\n\nglobal string $gMainPane;\nif (`paneLayout -exists $gMainPane`) {\n\n\tglobal int $gUseScenePanelConfig;\n\tint    $useSceneConfig = $gUseScenePanelConfig;\n\tint    $nodeEditorPanelVisible = stringArrayContains(\"nodeEditorPanel1\", `getPanel -vis`);\n\tint    $nodeEditorWorkspaceControlOpen = (`workspaceControl -exists nodeEditorPanel1Window` && `workspaceControl -q -visible nodeEditorPanel1Window`);\n\tint    $menusOkayInPanels = `optionVar -q allowMenusInPanels`;\n\tint    $nVisPanes = `paneLayout -q -nvp $gMainPane`;\n\tint    $nPanes = 0;\n\tstring $editorName;\n\tstring $panelName;\n\tstring $itemFilterName;\n\tstring $panelConfig;\n\n\t//\n\t//  get current state of the UI\n\t//\n\tsceneUIReplacement -update $gMainPane;\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"modelPanel\" (localizedPanelLabel(\"Top View\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tmodelPanel -edit -l (localizedPanelLabel(\"Top View\")) -mbv $menusOkayInPanels  $panelName;\n"
		+ "\t\t$editorName = $panelName;\n        modelEditor -e \n            -camera \"top\" \n            -useInteractiveMode 0\n            -displayLights \"default\" \n            -displayAppearance \"wireframe\" \n            -activeOnly 0\n            -ignorePanZoom 0\n            -wireframeOnShaded 0\n            -headsUpDisplay 1\n            -holdOuts 1\n            -selectionHiliteDisplay 1\n            -useDefaultMaterial 0\n            -bufferMode \"double\" \n            -twoSidedLighting 0\n            -backfaceCulling 0\n            -xray 0\n            -jointXray 0\n            -activeComponentsXray 0\n            -displayTextures 0\n            -smoothWireframe 0\n            -lineWidth 1\n            -textureAnisotropic 0\n            -textureHilight 1\n            -textureSampling 2\n            -textureDisplay \"modulate\" \n            -textureMaxSize 32768\n            -fogging 0\n            -fogSource \"fragment\" \n            -fogMode \"linear\" \n            -fogStart 0\n            -fogEnd 100\n            -fogDensity 0.1\n            -fogColor 0.5 0.5 0.5 1 \n"
		+ "            -depthOfFieldPreview 1\n            -maxConstantTransparency 1\n            -rendererName \"vp2Renderer\" \n            -objectFilterShowInHUD 1\n            -isFiltered 0\n            -colorResolution 256 256 \n            -bumpResolution 512 512 \n            -textureCompression 0\n            -transparencyAlgorithm \"frontAndBackCull\" \n            -transpInShadows 0\n            -cullingOverride \"none\" \n            -lowQualityLighting 0\n            -maximumNumHardwareLights 1\n            -occlusionCulling 0\n            -shadingModel 0\n            -useBaseRenderer 0\n            -useReducedRenderer 0\n            -smallObjectCulling 0\n            -smallObjectThreshold -1 \n            -interactiveDisableShadows 0\n            -interactiveBackFaceCull 0\n            -sortTransparent 1\n            -controllers 1\n            -nurbsCurves 1\n            -nurbsSurfaces 1\n            -polymeshes 1\n            -subdivSurfaces 1\n            -planes 1\n            -lights 1\n            -cameras 1\n            -controlVertices 1\n"
		+ "            -hulls 1\n            -grid 1\n            -imagePlane 1\n            -joints 1\n            -ikHandles 1\n            -deformers 1\n            -dynamics 1\n            -particleInstancers 1\n            -fluids 1\n            -hairSystems 1\n            -follicles 1\n            -nCloths 1\n            -nParticles 1\n            -nRigids 1\n            -dynamicConstraints 1\n            -locators 1\n            -manipulators 1\n            -pluginShapes 1\n            -dimensions 1\n            -handles 1\n            -pivots 1\n            -textures 1\n            -strokes 1\n            -motionTrails 1\n            -clipGhosts 1\n            -greasePencils 1\n            -shadows 0\n            -captureSequenceNumber -1\n            -width 645\n            -height 327\n            -sceneRenderFilter 0\n            $editorName;\n        modelEditor -e -viewSelected 0 $editorName;\n        modelEditor -e \n            -pluginObjects \"gpuCacheDisplayFilter\" 1 \n            $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n"
		+ "\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"modelPanel\" (localizedPanelLabel(\"Side View\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tmodelPanel -edit -l (localizedPanelLabel(\"Side View\")) -mbv $menusOkayInPanels  $panelName;\n\t\t$editorName = $panelName;\n        modelEditor -e \n            -camera \"side\" \n            -useInteractiveMode 0\n            -displayLights \"default\" \n            -displayAppearance \"wireframe\" \n            -activeOnly 0\n            -ignorePanZoom 0\n            -wireframeOnShaded 0\n            -headsUpDisplay 1\n            -holdOuts 1\n            -selectionHiliteDisplay 1\n            -useDefaultMaterial 0\n            -bufferMode \"double\" \n            -twoSidedLighting 0\n            -backfaceCulling 0\n            -xray 0\n            -jointXray 0\n            -activeComponentsXray 0\n            -displayTextures 0\n            -smoothWireframe 0\n            -lineWidth 1\n            -textureAnisotropic 0\n            -textureHilight 1\n            -textureSampling 2\n"
		+ "            -textureDisplay \"modulate\" \n            -textureMaxSize 32768\n            -fogging 0\n            -fogSource \"fragment\" \n            -fogMode \"linear\" \n            -fogStart 0\n            -fogEnd 100\n            -fogDensity 0.1\n            -fogColor 0.5 0.5 0.5 1 \n            -depthOfFieldPreview 1\n            -maxConstantTransparency 1\n            -rendererName \"vp2Renderer\" \n            -objectFilterShowInHUD 1\n            -isFiltered 0\n            -colorResolution 256 256 \n            -bumpResolution 512 512 \n            -textureCompression 0\n            -transparencyAlgorithm \"frontAndBackCull\" \n            -transpInShadows 0\n            -cullingOverride \"none\" \n            -lowQualityLighting 0\n            -maximumNumHardwareLights 1\n            -occlusionCulling 0\n            -shadingModel 0\n            -useBaseRenderer 0\n            -useReducedRenderer 0\n            -smallObjectCulling 0\n            -smallObjectThreshold -1 \n            -interactiveDisableShadows 0\n            -interactiveBackFaceCull 0\n"
		+ "            -sortTransparent 1\n            -controllers 1\n            -nurbsCurves 1\n            -nurbsSurfaces 1\n            -polymeshes 1\n            -subdivSurfaces 1\n            -planes 1\n            -lights 1\n            -cameras 1\n            -controlVertices 1\n            -hulls 1\n            -grid 1\n            -imagePlane 1\n            -joints 1\n            -ikHandles 1\n            -deformers 1\n            -dynamics 1\n            -particleInstancers 1\n            -fluids 1\n            -hairSystems 1\n            -follicles 1\n            -nCloths 1\n            -nParticles 1\n            -nRigids 1\n            -dynamicConstraints 1\n            -locators 1\n            -manipulators 1\n            -pluginShapes 1\n            -dimensions 1\n            -handles 1\n            -pivots 1\n            -textures 1\n            -strokes 1\n            -motionTrails 1\n            -clipGhosts 1\n            -greasePencils 1\n            -shadows 0\n            -captureSequenceNumber -1\n            -width 644\n            -height 327\n"
		+ "            -sceneRenderFilter 0\n            $editorName;\n        modelEditor -e -viewSelected 0 $editorName;\n        modelEditor -e \n            -pluginObjects \"gpuCacheDisplayFilter\" 1 \n            $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"modelPanel\" (localizedPanelLabel(\"Front View\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tmodelPanel -edit -l (localizedPanelLabel(\"Front View\")) -mbv $menusOkayInPanels  $panelName;\n\t\t$editorName = $panelName;\n        modelEditor -e \n            -camera \"front\" \n            -useInteractiveMode 0\n            -displayLights \"default\" \n            -displayAppearance \"wireframe\" \n            -activeOnly 0\n            -ignorePanZoom 0\n            -wireframeOnShaded 0\n            -headsUpDisplay 1\n            -holdOuts 1\n            -selectionHiliteDisplay 1\n            -useDefaultMaterial 0\n            -bufferMode \"double\" \n            -twoSidedLighting 0\n            -backfaceCulling 0\n"
		+ "            -xray 0\n            -jointXray 0\n            -activeComponentsXray 0\n            -displayTextures 0\n            -smoothWireframe 0\n            -lineWidth 1\n            -textureAnisotropic 0\n            -textureHilight 1\n            -textureSampling 2\n            -textureDisplay \"modulate\" \n            -textureMaxSize 32768\n            -fogging 0\n            -fogSource \"fragment\" \n            -fogMode \"linear\" \n            -fogStart 0\n            -fogEnd 100\n            -fogDensity 0.1\n            -fogColor 0.5 0.5 0.5 1 \n            -depthOfFieldPreview 1\n            -maxConstantTransparency 1\n            -rendererName \"vp2Renderer\" \n            -objectFilterShowInHUD 1\n            -isFiltered 0\n            -colorResolution 256 256 \n            -bumpResolution 512 512 \n            -textureCompression 0\n            -transparencyAlgorithm \"frontAndBackCull\" \n            -transpInShadows 0\n            -cullingOverride \"none\" \n            -lowQualityLighting 0\n            -maximumNumHardwareLights 1\n            -occlusionCulling 0\n"
		+ "            -shadingModel 0\n            -useBaseRenderer 0\n            -useReducedRenderer 0\n            -smallObjectCulling 0\n            -smallObjectThreshold -1 \n            -interactiveDisableShadows 0\n            -interactiveBackFaceCull 0\n            -sortTransparent 1\n            -controllers 1\n            -nurbsCurves 1\n            -nurbsSurfaces 1\n            -polymeshes 1\n            -subdivSurfaces 1\n            -planes 1\n            -lights 1\n            -cameras 1\n            -controlVertices 1\n            -hulls 1\n            -grid 1\n            -imagePlane 1\n            -joints 1\n            -ikHandles 1\n            -deformers 1\n            -dynamics 1\n            -particleInstancers 1\n            -fluids 1\n            -hairSystems 1\n            -follicles 1\n            -nCloths 1\n            -nParticles 1\n            -nRigids 1\n            -dynamicConstraints 1\n            -locators 1\n            -manipulators 1\n            -pluginShapes 1\n            -dimensions 1\n            -handles 1\n            -pivots 1\n"
		+ "            -textures 1\n            -strokes 1\n            -motionTrails 1\n            -clipGhosts 1\n            -greasePencils 1\n            -shadows 0\n            -captureSequenceNumber -1\n            -width 645\n            -height 327\n            -sceneRenderFilter 0\n            $editorName;\n        modelEditor -e -viewSelected 0 $editorName;\n        modelEditor -e \n            -pluginObjects \"gpuCacheDisplayFilter\" 1 \n            $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"modelPanel\" (localizedPanelLabel(\"Persp View\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tmodelPanel -edit -l (localizedPanelLabel(\"Persp View\")) -mbv $menusOkayInPanels  $panelName;\n\t\t$editorName = $panelName;\n        modelEditor -e \n            -camera \"persp\" \n            -useInteractiveMode 0\n            -displayLights \"default\" \n            -displayAppearance \"smoothShaded\" \n            -activeOnly 0\n            -ignorePanZoom 0\n"
		+ "            -wireframeOnShaded 0\n            -headsUpDisplay 1\n            -holdOuts 1\n            -selectionHiliteDisplay 1\n            -useDefaultMaterial 0\n            -bufferMode \"double\" \n            -twoSidedLighting 0\n            -backfaceCulling 0\n            -xray 0\n            -jointXray 0\n            -activeComponentsXray 0\n            -displayTextures 0\n            -smoothWireframe 0\n            -lineWidth 1\n            -textureAnisotropic 0\n            -textureHilight 1\n            -textureSampling 2\n            -textureDisplay \"modulate\" \n            -textureMaxSize 32768\n            -fogging 0\n            -fogSource \"fragment\" \n            -fogMode \"linear\" \n            -fogStart 0\n            -fogEnd 100\n            -fogDensity 0.1\n            -fogColor 0.5 0.5 0.5 1 \n            -depthOfFieldPreview 1\n            -maxConstantTransparency 1\n            -rendererName \"vp2Renderer\" \n            -objectFilterShowInHUD 1\n            -isFiltered 0\n            -colorResolution 256 256 \n            -bumpResolution 512 512 \n"
		+ "            -textureCompression 0\n            -transparencyAlgorithm \"frontAndBackCull\" \n            -transpInShadows 0\n            -cullingOverride \"none\" \n            -lowQualityLighting 0\n            -maximumNumHardwareLights 1\n            -occlusionCulling 0\n            -shadingModel 0\n            -useBaseRenderer 0\n            -useReducedRenderer 0\n            -smallObjectCulling 0\n            -smallObjectThreshold -1 \n            -interactiveDisableShadows 0\n            -interactiveBackFaceCull 0\n            -sortTransparent 1\n            -controllers 1\n            -nurbsCurves 1\n            -nurbsSurfaces 1\n            -polymeshes 1\n            -subdivSurfaces 1\n            -planes 1\n            -lights 1\n            -cameras 1\n            -controlVertices 1\n            -hulls 1\n            -grid 1\n            -imagePlane 1\n            -joints 1\n            -ikHandles 1\n            -deformers 1\n            -dynamics 1\n            -particleInstancers 1\n            -fluids 1\n            -hairSystems 1\n            -follicles 1\n"
		+ "            -nCloths 1\n            -nParticles 1\n            -nRigids 1\n            -dynamicConstraints 1\n            -locators 1\n            -manipulators 1\n            -pluginShapes 1\n            -dimensions 1\n            -handles 1\n            -pivots 1\n            -textures 1\n            -strokes 1\n            -motionTrails 1\n            -clipGhosts 1\n            -greasePencils 1\n            -shadows 0\n            -captureSequenceNumber -1\n            -width 1300\n            -height 702\n            -sceneRenderFilter 0\n            $editorName;\n        modelEditor -e -viewSelected 0 $editorName;\n        modelEditor -e \n            -pluginObjects \"gpuCacheDisplayFilter\" 1 \n            $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"outlinerPanel\" (localizedPanelLabel(\"ToggledOutliner\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\toutlinerPanel -edit -l (localizedPanelLabel(\"ToggledOutliner\")) -mbv $menusOkayInPanels  $panelName;\n"
		+ "\t\t$editorName = $panelName;\n        outlinerEditor -e \n            -showShapes 0\n            -showAssignedMaterials 0\n            -showTimeEditor 1\n            -showReferenceNodes 1\n            -showReferenceMembers 1\n            -showAttributes 0\n            -showConnected 0\n            -showAnimCurvesOnly 0\n            -showMuteInfo 0\n            -organizeByLayer 1\n            -organizeByClip 1\n            -showAnimLayerWeight 1\n            -autoExpandLayers 1\n            -autoExpand 0\n            -showDagOnly 1\n            -showAssets 1\n            -showContainedOnly 1\n            -showPublishedAsConnected 0\n            -showParentContainers 0\n            -showContainerContents 1\n            -ignoreDagHierarchy 0\n            -expandConnections 0\n            -showUpstreamCurves 1\n            -showUnitlessCurves 1\n            -showCompounds 1\n            -showLeafs 1\n            -showNumericAttrsOnly 0\n            -highlightActive 1\n            -autoSelectNewObjects 0\n            -doNotSelectNewObjects 0\n            -dropIsParent 1\n"
		+ "            -transmitFilters 0\n            -setFilter \"defaultSetFilter\" \n            -showSetMembers 1\n            -allowMultiSelection 1\n            -alwaysToggleSelect 0\n            -directSelect 0\n            -isSet 0\n            -isSetMember 0\n            -displayMode \"DAG\" \n            -expandObjects 0\n            -setsIgnoreFilters 1\n            -containersIgnoreFilters 0\n            -editAttrName 0\n            -showAttrValues 0\n            -highlightSecondary 0\n            -showUVAttrsOnly 0\n            -showTextureNodesOnly 0\n            -attrAlphaOrder \"default\" \n            -animLayerFilterOptions \"allAffecting\" \n            -sortOrder \"none\" \n            -longNames 0\n            -niceNames 1\n            -showNamespace 1\n            -showPinIcons 0\n            -mapMotionTrails 0\n            -ignoreHiddenAttribute 0\n            -ignoreOutlinerColor 0\n            -renderFilterVisible 0\n            -renderFilterIndex 0\n            -selectionOrder \"chronological\" \n            -expandAttribute 0\n            $editorName;\n"
		+ "\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"outlinerPanel\" (localizedPanelLabel(\"Outliner\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\toutlinerPanel -edit -l (localizedPanelLabel(\"Outliner\")) -mbv $menusOkayInPanels  $panelName;\n\t\t$editorName = $panelName;\n        outlinerEditor -e \n            -showShapes 0\n            -showAssignedMaterials 0\n            -showTimeEditor 1\n            -showReferenceNodes 0\n            -showReferenceMembers 0\n            -showAttributes 0\n            -showConnected 0\n            -showAnimCurvesOnly 0\n            -showMuteInfo 0\n            -organizeByLayer 1\n            -organizeByClip 1\n            -showAnimLayerWeight 1\n            -autoExpandLayers 1\n            -autoExpand 0\n            -showDagOnly 1\n            -showAssets 1\n            -showContainedOnly 1\n            -showPublishedAsConnected 0\n            -showParentContainers 0\n            -showContainerContents 1\n            -ignoreDagHierarchy 0\n"
		+ "            -expandConnections 0\n            -showUpstreamCurves 1\n            -showUnitlessCurves 1\n            -showCompounds 1\n            -showLeafs 1\n            -showNumericAttrsOnly 0\n            -highlightActive 1\n            -autoSelectNewObjects 0\n            -doNotSelectNewObjects 0\n            -dropIsParent 1\n            -transmitFilters 0\n            -setFilter \"defaultSetFilter\" \n            -showSetMembers 1\n            -allowMultiSelection 1\n            -alwaysToggleSelect 0\n            -directSelect 0\n            -displayMode \"DAG\" \n            -expandObjects 0\n            -setsIgnoreFilters 1\n            -containersIgnoreFilters 0\n            -editAttrName 0\n            -showAttrValues 0\n            -highlightSecondary 0\n            -showUVAttrsOnly 0\n            -showTextureNodesOnly 0\n            -attrAlphaOrder \"default\" \n            -animLayerFilterOptions \"allAffecting\" \n            -sortOrder \"none\" \n            -longNames 0\n            -niceNames 1\n            -showNamespace 1\n            -showPinIcons 0\n"
		+ "            -mapMotionTrails 0\n            -ignoreHiddenAttribute 0\n            -ignoreOutlinerColor 0\n            -renderFilterVisible 0\n            $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"graphEditor\" (localizedPanelLabel(\"Graph Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Graph Editor\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = ($panelName+\"OutlineEd\");\n            outlinerEditor -e \n                -showShapes 1\n                -showAssignedMaterials 0\n                -showTimeEditor 1\n                -showReferenceNodes 0\n                -showReferenceMembers 0\n                -showAttributes 1\n                -showConnected 1\n                -showAnimCurvesOnly 1\n                -showMuteInfo 0\n                -organizeByLayer 1\n                -organizeByClip 1\n                -showAnimLayerWeight 1\n                -autoExpandLayers 1\n"
		+ "                -autoExpand 1\n                -showDagOnly 0\n                -showAssets 1\n                -showContainedOnly 0\n                -showPublishedAsConnected 0\n                -showParentContainers 1\n                -showContainerContents 0\n                -ignoreDagHierarchy 0\n                -expandConnections 1\n                -showUpstreamCurves 1\n                -showUnitlessCurves 1\n                -showCompounds 0\n                -showLeafs 1\n                -showNumericAttrsOnly 1\n                -highlightActive 0\n                -autoSelectNewObjects 1\n                -doNotSelectNewObjects 0\n                -dropIsParent 1\n                -transmitFilters 1\n                -setFilter \"0\" \n                -showSetMembers 0\n                -allowMultiSelection 1\n                -alwaysToggleSelect 0\n                -directSelect 0\n                -displayMode \"DAG\" \n                -expandObjects 0\n                -setsIgnoreFilters 1\n                -containersIgnoreFilters 0\n                -editAttrName 0\n"
		+ "                -showAttrValues 0\n                -highlightSecondary 0\n                -showUVAttrsOnly 0\n                -showTextureNodesOnly 0\n                -attrAlphaOrder \"default\" \n                -animLayerFilterOptions \"allAffecting\" \n                -sortOrder \"none\" \n                -longNames 0\n                -niceNames 1\n                -showNamespace 1\n                -showPinIcons 1\n                -mapMotionTrails 1\n                -ignoreHiddenAttribute 0\n                -ignoreOutlinerColor 0\n                -renderFilterVisible 0\n                $editorName;\n\n\t\t\t$editorName = ($panelName+\"GraphEd\");\n            animCurveEditor -e \n                -displayKeys 1\n                -displayTangents 0\n                -displayActiveKeys 0\n                -displayActiveKeyTangents 1\n                -displayInfinities 0\n                -displayValues 0\n                -autoFit 1\n                -autoFitTime 0\n                -snapTime \"integer\" \n                -snapValue \"none\" \n                -showResults \"off\" \n"
		+ "                -showBufferCurves \"off\" \n                -smoothness \"fine\" \n                -resultSamples 1\n                -resultScreenSamples 0\n                -resultUpdate \"delayed\" \n                -showUpstreamCurves 1\n                -showCurveNames 0\n                -showActiveCurveNames 0\n                -stackedCurves 0\n                -stackedCurvesMin -1\n                -stackedCurvesMax 1\n                -stackedCurvesSpace 0.2\n                -displayNormalized 0\n                -preSelectionHighlight 0\n                -constrainDrag 0\n                -classicMode 1\n                -valueLinesToggle 1\n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"dopeSheetPanel\" (localizedPanelLabel(\"Dope Sheet\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Dope Sheet\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = ($panelName+\"OutlineEd\");\n"
		+ "            outlinerEditor -e \n                -showShapes 1\n                -showAssignedMaterials 0\n                -showTimeEditor 1\n                -showReferenceNodes 0\n                -showReferenceMembers 0\n                -showAttributes 1\n                -showConnected 1\n                -showAnimCurvesOnly 1\n                -showMuteInfo 0\n                -organizeByLayer 1\n                -organizeByClip 1\n                -showAnimLayerWeight 1\n                -autoExpandLayers 1\n                -autoExpand 0\n                -showDagOnly 0\n                -showAssets 1\n                -showContainedOnly 0\n                -showPublishedAsConnected 0\n                -showParentContainers 1\n                -showContainerContents 0\n                -ignoreDagHierarchy 0\n                -expandConnections 1\n                -showUpstreamCurves 1\n                -showUnitlessCurves 0\n                -showCompounds 1\n                -showLeafs 1\n                -showNumericAttrsOnly 1\n                -highlightActive 0\n"
		+ "                -autoSelectNewObjects 0\n                -doNotSelectNewObjects 1\n                -dropIsParent 1\n                -transmitFilters 0\n                -setFilter \"0\" \n                -showSetMembers 0\n                -allowMultiSelection 1\n                -alwaysToggleSelect 0\n                -directSelect 0\n                -displayMode \"DAG\" \n                -expandObjects 0\n                -setsIgnoreFilters 1\n                -containersIgnoreFilters 0\n                -editAttrName 0\n                -showAttrValues 0\n                -highlightSecondary 0\n                -showUVAttrsOnly 0\n                -showTextureNodesOnly 0\n                -attrAlphaOrder \"default\" \n                -animLayerFilterOptions \"allAffecting\" \n                -sortOrder \"none\" \n                -longNames 0\n                -niceNames 1\n                -showNamespace 1\n                -showPinIcons 0\n                -mapMotionTrails 1\n                -ignoreHiddenAttribute 0\n                -ignoreOutlinerColor 0\n                -renderFilterVisible 0\n"
		+ "                $editorName;\n\n\t\t\t$editorName = ($panelName+\"DopeSheetEd\");\n            dopeSheetEditor -e \n                -displayKeys 1\n                -displayTangents 0\n                -displayActiveKeys 0\n                -displayActiveKeyTangents 0\n                -displayInfinities 0\n                -displayValues 0\n                -autoFit 0\n                -autoFitTime 0\n                -snapTime \"integer\" \n                -snapValue \"none\" \n                -outliner \"dopeSheetPanel1OutlineEd\" \n                -showSummary 1\n                -showScene 0\n                -hierarchyBelow 0\n                -showTicks 1\n                -selectionWindow 0 0 0 0 \n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"timeEditorPanel\" (localizedPanelLabel(\"Time Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Time Editor\")) -mbv $menusOkayInPanels  $panelName;\n"
		+ "\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"clipEditorPanel\" (localizedPanelLabel(\"Trax Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Trax Editor\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = clipEditorNameFromPanel($panelName);\n            clipEditor -e \n                -displayKeys 0\n                -displayTangents 0\n                -displayActiveKeys 0\n                -displayActiveKeyTangents 0\n                -displayInfinities 0\n                -displayValues 0\n                -autoFit 0\n                -autoFitTime 0\n                -snapTime \"none\" \n                -snapValue \"none\" \n                -initialized 0\n                -manageSequencer 0 \n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"sequenceEditorPanel\" (localizedPanelLabel(\"Camera Sequencer\")) `;\n"
		+ "\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Camera Sequencer\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = sequenceEditorNameFromPanel($panelName);\n            clipEditor -e \n                -displayKeys 0\n                -displayTangents 0\n                -displayActiveKeys 0\n                -displayActiveKeyTangents 0\n                -displayInfinities 0\n                -displayValues 0\n                -autoFit 0\n                -autoFitTime 0\n                -snapTime \"none\" \n                -snapValue \"none\" \n                -initialized 0\n                -manageSequencer 1 \n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"hyperGraphPanel\" (localizedPanelLabel(\"Hypergraph Hierarchy\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Hypergraph Hierarchy\")) -mbv $menusOkayInPanels  $panelName;\n"
		+ "\n\t\t\t$editorName = ($panelName+\"HyperGraphEd\");\n            hyperGraph -e \n                -graphLayoutStyle \"hierarchicalLayout\" \n                -orientation \"horiz\" \n                -mergeConnections 0\n                -zoom 1\n                -animateTransition 0\n                -showRelationships 1\n                -showShapes 0\n                -showDeformers 0\n                -showExpressions 0\n                -showConstraints 0\n                -showConnectionFromSelected 0\n                -showConnectionToSelected 0\n                -showConstraintLabels 0\n                -showUnderworld 0\n                -showInvisible 0\n                -transitionFrames 1\n                -opaqueContainers 0\n                -freeform 0\n                -imagePosition 0 0 \n                -imageScale 1\n                -imageEnabled 0\n                -graphType \"DAG\" \n                -heatMapDisplay 0\n                -updateSelection 1\n                -updateNodeAdded 1\n                -useDrawOverrideColor 0\n                -limitGraphTraversal -1\n"
		+ "                -range 0 0 \n                -iconSize \"smallIcons\" \n                -showCachedConnections 0\n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"hyperShadePanel\" (localizedPanelLabel(\"Hypershade\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Hypershade\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"visorPanel\" (localizedPanelLabel(\"Visor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Visor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"nodeEditorPanel\" (localizedPanelLabel(\"Node Editor\")) `;\n\tif ($nodeEditorPanelVisible || $nodeEditorWorkspaceControlOpen) {\n"
		+ "\t\tif (\"\" == $panelName) {\n\t\t\tif ($useSceneConfig) {\n\t\t\t\t$panelName = `scriptedPanel -unParent  -type \"nodeEditorPanel\" -l (localizedPanelLabel(\"Node Editor\")) -mbv $menusOkayInPanels `;\n\n\t\t\t$editorName = ($panelName+\"NodeEditorEd\");\n            nodeEditor -e \n                -allAttributes 0\n                -allNodes 0\n                -autoSizeNodes 1\n                -consistentNameSize 1\n                -createNodeCommand \"nodeEdCreateNodeCommand\" \n                -connectNodeOnCreation 0\n                -connectOnDrop 0\n                -copyConnectionsOnPaste 0\n                -connectionStyle \"bezier\" \n                -defaultPinnedState 0\n                -additiveGraphingMode 0\n                -settingsChangedCallback \"nodeEdSyncControls\" \n                -traversalDepthLimit -1\n                -keyPressCommand \"nodeEdKeyPressCommand\" \n                -nodeTitleMode \"name\" \n                -gridSnap 0\n                -gridVisibility 1\n                -crosshairOnEdgeDragging 0\n                -popupMenuScript \"nodeEdBuildPanelMenus\" \n"
		+ "                -showNamespace 1\n                -showShapes 1\n                -showSGShapes 0\n                -showTransforms 1\n                -useAssets 1\n                -syncedSelection 1\n                -extendToShapes 1\n                -editorMode \"default\" \n                -hasWatchpoint 0\n                $editorName;\n\t\t\t}\n\t\t} else {\n\t\t\t$label = `panel -q -label $panelName`;\n\t\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Node Editor\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = ($panelName+\"NodeEditorEd\");\n            nodeEditor -e \n                -allAttributes 0\n                -allNodes 0\n                -autoSizeNodes 1\n                -consistentNameSize 1\n                -createNodeCommand \"nodeEdCreateNodeCommand\" \n                -connectNodeOnCreation 0\n                -connectOnDrop 0\n                -copyConnectionsOnPaste 0\n                -connectionStyle \"bezier\" \n                -defaultPinnedState 0\n                -additiveGraphingMode 0\n                -settingsChangedCallback \"nodeEdSyncControls\" \n"
		+ "                -traversalDepthLimit -1\n                -keyPressCommand \"nodeEdKeyPressCommand\" \n                -nodeTitleMode \"name\" \n                -gridSnap 0\n                -gridVisibility 1\n                -crosshairOnEdgeDragging 0\n                -popupMenuScript \"nodeEdBuildPanelMenus\" \n                -showNamespace 1\n                -showShapes 1\n                -showSGShapes 0\n                -showTransforms 1\n                -useAssets 1\n                -syncedSelection 1\n                -extendToShapes 1\n                -editorMode \"default\" \n                -hasWatchpoint 0\n                $editorName;\n\t\t\tif (!$useSceneConfig) {\n\t\t\t\tpanel -e -l $label $panelName;\n\t\t\t}\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"createNodePanel\" (localizedPanelLabel(\"Create Node\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Create Node\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n"
		+ "\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"polyTexturePlacementPanel\" (localizedPanelLabel(\"UV Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"UV Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"renderWindowPanel\" (localizedPanelLabel(\"Render View\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Render View\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"shapePanel\" (localizedPanelLabel(\"Shape Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tshapePanel -edit -l (localizedPanelLabel(\"Shape Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n"
		+ "\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"posePanel\" (localizedPanelLabel(\"Pose Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tposePanel -edit -l (localizedPanelLabel(\"Pose Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"dynRelEdPanel\" (localizedPanelLabel(\"Dynamic Relationships\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Dynamic Relationships\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"relationshipPanel\" (localizedPanelLabel(\"Relationship Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Relationship Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n"
		+ "\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"referenceEditorPanel\" (localizedPanelLabel(\"Reference Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Reference Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"componentEditorPanel\" (localizedPanelLabel(\"Component Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Component Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"dynPaintScriptedPanelType\" (localizedPanelLabel(\"Paint Effects\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Paint Effects\")) -mbv $menusOkayInPanels  $panelName;\n"
		+ "\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"scriptEditorPanel\" (localizedPanelLabel(\"Script Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Script Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"profilerPanel\" (localizedPanelLabel(\"Profiler Tool\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Profiler Tool\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"contentBrowserPanel\" (localizedPanelLabel(\"Content Browser\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Content Browser\")) -mbv $menusOkayInPanels  $panelName;\n"
		+ "\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\tif ($useSceneConfig) {\n        string $configName = `getPanel -cwl (localizedPanelLabel(\"Current Layout\"))`;\n        if (\"\" != $configName) {\n\t\t\tpanelConfiguration -edit -label (localizedPanelLabel(\"Current Layout\")) \n\t\t\t\t-userCreated false\n\t\t\t\t-defaultImage \"vacantCell.xpm\"\n\t\t\t\t-image \"\"\n\t\t\t\t-sc false\n\t\t\t\t-configString \"global string $gMainPane; paneLayout -e -cn \\\"single\\\" -ps 1 100 100 $gMainPane;\"\n\t\t\t\t-removeAllPanels\n\t\t\t\t-ap false\n\t\t\t\t\t(localizedPanelLabel(\"Persp View\")) \n\t\t\t\t\t\"modelPanel\"\n"
		+ "\t\t\t\t\t\"$panelName = `modelPanel -unParent -l (localizedPanelLabel(\\\"Persp View\\\")) -mbv $menusOkayInPanels `;\\n$editorName = $panelName;\\nmodelEditor -e \\n    -cam `findStartUpCamera persp` \\n    -useInteractiveMode 0\\n    -displayLights \\\"default\\\" \\n    -displayAppearance \\\"smoothShaded\\\" \\n    -activeOnly 0\\n    -ignorePanZoom 0\\n    -wireframeOnShaded 0\\n    -headsUpDisplay 1\\n    -holdOuts 1\\n    -selectionHiliteDisplay 1\\n    -useDefaultMaterial 0\\n    -bufferMode \\\"double\\\" \\n    -twoSidedLighting 0\\n    -backfaceCulling 0\\n    -xray 0\\n    -jointXray 0\\n    -activeComponentsXray 0\\n    -displayTextures 0\\n    -smoothWireframe 0\\n    -lineWidth 1\\n    -textureAnisotropic 0\\n    -textureHilight 1\\n    -textureSampling 2\\n    -textureDisplay \\\"modulate\\\" \\n    -textureMaxSize 32768\\n    -fogging 0\\n    -fogSource \\\"fragment\\\" \\n    -fogMode \\\"linear\\\" \\n    -fogStart 0\\n    -fogEnd 100\\n    -fogDensity 0.1\\n    -fogColor 0.5 0.5 0.5 1 \\n    -depthOfFieldPreview 1\\n    -maxConstantTransparency 1\\n    -rendererName \\\"vp2Renderer\\\" \\n    -objectFilterShowInHUD 1\\n    -isFiltered 0\\n    -colorResolution 256 256 \\n    -bumpResolution 512 512 \\n    -textureCompression 0\\n    -transparencyAlgorithm \\\"frontAndBackCull\\\" \\n    -transpInShadows 0\\n    -cullingOverride \\\"none\\\" \\n    -lowQualityLighting 0\\n    -maximumNumHardwareLights 1\\n    -occlusionCulling 0\\n    -shadingModel 0\\n    -useBaseRenderer 0\\n    -useReducedRenderer 0\\n    -smallObjectCulling 0\\n    -smallObjectThreshold -1 \\n    -interactiveDisableShadows 0\\n    -interactiveBackFaceCull 0\\n    -sortTransparent 1\\n    -controllers 1\\n    -nurbsCurves 1\\n    -nurbsSurfaces 1\\n    -polymeshes 1\\n    -subdivSurfaces 1\\n    -planes 1\\n    -lights 1\\n    -cameras 1\\n    -controlVertices 1\\n    -hulls 1\\n    -grid 1\\n    -imagePlane 1\\n    -joints 1\\n    -ikHandles 1\\n    -deformers 1\\n    -dynamics 1\\n    -particleInstancers 1\\n    -fluids 1\\n    -hairSystems 1\\n    -follicles 1\\n    -nCloths 1\\n    -nParticles 1\\n    -nRigids 1\\n    -dynamicConstraints 1\\n    -locators 1\\n    -manipulators 1\\n    -pluginShapes 1\\n    -dimensions 1\\n    -handles 1\\n    -pivots 1\\n    -textures 1\\n    -strokes 1\\n    -motionTrails 1\\n    -clipGhosts 1\\n    -greasePencils 1\\n    -shadows 0\\n    -captureSequenceNumber -1\\n    -width 1300\\n    -height 702\\n    -sceneRenderFilter 0\\n    $editorName;\\nmodelEditor -e -viewSelected 0 $editorName;\\nmodelEditor -e \\n    -pluginObjects \\\"gpuCacheDisplayFilter\\\" 1 \\n    $editorName\"\n"
		+ "\t\t\t\t\t\"modelPanel -edit -l (localizedPanelLabel(\\\"Persp View\\\")) -mbv $menusOkayInPanels  $panelName;\\n$editorName = $panelName;\\nmodelEditor -e \\n    -cam `findStartUpCamera persp` \\n    -useInteractiveMode 0\\n    -displayLights \\\"default\\\" \\n    -displayAppearance \\\"smoothShaded\\\" \\n    -activeOnly 0\\n    -ignorePanZoom 0\\n    -wireframeOnShaded 0\\n    -headsUpDisplay 1\\n    -holdOuts 1\\n    -selectionHiliteDisplay 1\\n    -useDefaultMaterial 0\\n    -bufferMode \\\"double\\\" \\n    -twoSidedLighting 0\\n    -backfaceCulling 0\\n    -xray 0\\n    -jointXray 0\\n    -activeComponentsXray 0\\n    -displayTextures 0\\n    -smoothWireframe 0\\n    -lineWidth 1\\n    -textureAnisotropic 0\\n    -textureHilight 1\\n    -textureSampling 2\\n    -textureDisplay \\\"modulate\\\" \\n    -textureMaxSize 32768\\n    -fogging 0\\n    -fogSource \\\"fragment\\\" \\n    -fogMode \\\"linear\\\" \\n    -fogStart 0\\n    -fogEnd 100\\n    -fogDensity 0.1\\n    -fogColor 0.5 0.5 0.5 1 \\n    -depthOfFieldPreview 1\\n    -maxConstantTransparency 1\\n    -rendererName \\\"vp2Renderer\\\" \\n    -objectFilterShowInHUD 1\\n    -isFiltered 0\\n    -colorResolution 256 256 \\n    -bumpResolution 512 512 \\n    -textureCompression 0\\n    -transparencyAlgorithm \\\"frontAndBackCull\\\" \\n    -transpInShadows 0\\n    -cullingOverride \\\"none\\\" \\n    -lowQualityLighting 0\\n    -maximumNumHardwareLights 1\\n    -occlusionCulling 0\\n    -shadingModel 0\\n    -useBaseRenderer 0\\n    -useReducedRenderer 0\\n    -smallObjectCulling 0\\n    -smallObjectThreshold -1 \\n    -interactiveDisableShadows 0\\n    -interactiveBackFaceCull 0\\n    -sortTransparent 1\\n    -controllers 1\\n    -nurbsCurves 1\\n    -nurbsSurfaces 1\\n    -polymeshes 1\\n    -subdivSurfaces 1\\n    -planes 1\\n    -lights 1\\n    -cameras 1\\n    -controlVertices 1\\n    -hulls 1\\n    -grid 1\\n    -imagePlane 1\\n    -joints 1\\n    -ikHandles 1\\n    -deformers 1\\n    -dynamics 1\\n    -particleInstancers 1\\n    -fluids 1\\n    -hairSystems 1\\n    -follicles 1\\n    -nCloths 1\\n    -nParticles 1\\n    -nRigids 1\\n    -dynamicConstraints 1\\n    -locators 1\\n    -manipulators 1\\n    -pluginShapes 1\\n    -dimensions 1\\n    -handles 1\\n    -pivots 1\\n    -textures 1\\n    -strokes 1\\n    -motionTrails 1\\n    -clipGhosts 1\\n    -greasePencils 1\\n    -shadows 0\\n    -captureSequenceNumber -1\\n    -width 1300\\n    -height 702\\n    -sceneRenderFilter 0\\n    $editorName;\\nmodelEditor -e -viewSelected 0 $editorName;\\nmodelEditor -e \\n    -pluginObjects \\\"gpuCacheDisplayFilter\\\" 1 \\n    $editorName\"\n"
		+ "\t\t\t\t$configName;\n\n            setNamedPanelLayout (localizedPanelLabel(\"Current Layout\"));\n        }\n\n        panelHistory -e -clear mainPanelHistory;\n        sceneUIReplacement -clear;\n\t}\n\n\ngrid -spacing 5 -size 12 -divisions 5 -displayAxes yes -displayGridLines yes -displayDivisionLines yes -displayPerspectiveLabels no -displayOrthographicLabels no -displayAxesBold yes -perspectiveLabelPosition axis -orthographicLabelPosition edge;\nviewManip -drawCompass 0 -compassAngle 0 -frontParameters \"\" -homeParameters \"\" -selectionLockParameters \"\";\n}\n");
	setAttr ".st" 3;
createNode script -n "sceneConfigurationScriptNode";
	rename -uid "8D3B992E-4F34-9E8B-F055-61B0FABBE1A5";
	setAttr ".b" -type "string" "playbackOptions -min 1 -max 120 -ast 1 -aet 200 ";
	setAttr ".st" 6;
select -ne :time1;
	setAttr ".o" 1;
	setAttr ".unw" 1;
select -ne :hardwareRenderingGlobals;
	setAttr ".otfna" -type "stringArray" 22 "NURBS Curves" "NURBS Surfaces" "Polygons" "Subdiv Surface" "Particles" "Particle Instance" "Fluids" "Strokes" "Image Planes" "UI" "Lights" "Cameras" "Locators" "Joints" "IK Handles" "Deformers" "Motion Trails" "Components" "Hair Systems" "Follicles" "Misc. UI" "Ornaments"  ;
	setAttr ".otfva" -type "Int32Array" 22 0 1 1 1 1 1
		 1 1 1 0 0 0 0 0 0 0 0 0
		 0 0 0 0 ;
	setAttr ".fprt" yes;
select -ne :renderPartition;
	setAttr -s 2 ".st";
select -ne :renderGlobalsList1;
select -ne :defaultShaderList1;
	setAttr -s 4 ".s";
select -ne :postProcessList1;
	setAttr -s 2 ".p";
select -ne :defaultRenderingList1;
select -ne :initialShadingGroup;
	setAttr -s 3 ".dsm";
	setAttr ".ro" yes;
select -ne :initialParticleSE;
	setAttr ".ro" yes;
select -ne :defaultResolution;
	setAttr ".pa" 1;
select -ne :hardwareRenderGlobals;
	setAttr ".ctrs" 256;
	setAttr ".btrs" 512;
connectAttr "polySphere1.out" "HeadShape.i";
connectAttr "polySplit3.out" "|Body|OG_Body|OG_BodyShape.i";
relationship "link" ":lightLinker1" ":initialShadingGroup.message" ":defaultLightSet.message";
relationship "link" ":lightLinker1" ":initialParticleSE.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" ":initialShadingGroup.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" ":initialParticleSE.message" ":defaultLightSet.message";
connectAttr "layerManager.dli[0]" "defaultLayer.id";
connectAttr "renderLayerManager.rlmi[0]" "defaultRenderLayer.rlid";
connectAttr "polyCube1.out" "polySplitRing1.ip";
connectAttr "|Body|OG_half|OG_BodyShape.wm" "polySplitRing1.mp";
connectAttr "polySplitRing1.out" "polySplitRing2.ip";
connectAttr "|Body|OG_half|OG_BodyShape.wm" "polySplitRing2.mp";
connectAttr "polySplitRing2.out" "polySplitRing3.ip";
connectAttr "|Body|OG_half|OG_BodyShape.wm" "polySplitRing3.mp";
connectAttr "polySplitRing3.out" "polySplitRing4.ip";
connectAttr "|Body|OG_half|OG_BodyShape.wm" "polySplitRing4.mp";
connectAttr "polySplitRing4.out" "polySplitRing5.ip";
connectAttr "|Body|OG_half|OG_BodyShape.wm" "polySplitRing5.mp";
connectAttr "polySplitRing5.out" "polyExtrudeFace1.ip";
connectAttr "|Body|OG_half|OG_BodyShape.wm" "polyExtrudeFace1.mp";
connectAttr "polyExtrudeFace1.out" "polyExtrudeFace2.ip";
connectAttr "|Body|OG_half|OG_BodyShape.wm" "polyExtrudeFace2.mp";
connectAttr "polyExtrudeFace2.out" "polyExtrudeFace3.ip";
connectAttr "|Body|OG_half|OG_BodyShape.wm" "polyExtrudeFace3.mp";
connectAttr "polyExtrudeFace3.out" "polyExtrudeFace4.ip";
connectAttr "|Body|OG_half|OG_BodyShape.wm" "polyExtrudeFace4.mp";
connectAttr "polyExtrudeFace4.out" "polyExtrudeFace5.ip";
connectAttr "|Body|OG_half|OG_BodyShape.wm" "polyExtrudeFace5.mp";
connectAttr "polyExtrudeFace5.out" "polyExtrudeFace6.ip";
connectAttr "|Body|OG_half|OG_BodyShape.wm" "polyExtrudeFace6.mp";
connectAttr "polyExtrudeFace6.out" "polyExtrudeFace7.ip";
connectAttr "|Body|OG_half|OG_BodyShape.wm" "polyExtrudeFace7.mp";
connectAttr "polyExtrudeFace7.out" "polyTweak1.ip";
connectAttr "polyTweak1.out" "deleteComponent1.ig";
connectAttr "deleteComponent1.og" "deleteComponent2.ig";
connectAttr "deleteComponent2.og" "polyCloseBorder1.ip";
connectAttr "polyCloseBorder1.out" "polySplit1.ip";
connectAttr "polySplit1.out" "polyExtrudeFace8.ip";
connectAttr "|Body|OG_half|OG_BodyShape.wm" "polyExtrudeFace8.mp";
connectAttr "polyExtrudeFace8.out" "polyExtrudeFace9.ip";
connectAttr "|Body|OG_half|OG_BodyShape.wm" "polyExtrudeFace9.mp";
connectAttr "polyExtrudeFace9.out" "polyExtrudeFace10.ip";
connectAttr "|Body|OG_half|OG_BodyShape.wm" "polyExtrudeFace10.mp";
connectAttr "polyExtrudeFace10.out" "polyExtrudeFace11.ip";
connectAttr "|Body|OG_half|OG_BodyShape.wm" "polyExtrudeFace11.mp";
connectAttr "polyTweak2.out" "polySplitEdge1.ip";
connectAttr "polyExtrudeFace11.out" "polyTweak2.ip";
connectAttr "polySplitEdge1.out" "polySplitEdge2.ip";
connectAttr "polySplitEdge2.out" "polySplitEdge3.ip";
connectAttr "polySplitEdge3.out" "deleteComponent3.ig";
connectAttr "deleteComponent3.og" "deleteComponent4.ig";
connectAttr "deleteComponent4.og" "polyMergeVert1.ip";
connectAttr "|Body|OG_half|OG_BodyShape.wm" "polyMergeVert1.mp";
connectAttr "polyTweak3.out" "polyExtrudeFace12.ip";
connectAttr "|Body|OG_half|OG_BodyShape.wm" "polyExtrudeFace12.mp";
connectAttr "polyMergeVert1.out" "polyTweak3.ip";
connectAttr "polyExtrudeFace12.out" "polyExtrudeFace13.ip";
connectAttr "|Body|OG_half|OG_BodyShape.wm" "polyExtrudeFace13.mp";
connectAttr "polyExtrudeFace13.out" "polyExtrudeFace14.ip";
connectAttr "|Body|OG_half|OG_BodyShape.wm" "polyExtrudeFace14.mp";
connectAttr "polyExtrudeFace14.out" "polySplit2.ip";
connectAttr "polySplit2.out" "polyExtrudeFace15.ip";
connectAttr "|Body|OG_half|OG_BodyShape.wm" "polyExtrudeFace15.mp";
connectAttr "polyExtrudeFace15.out" "polyExtrudeFace16.ip";
connectAttr "|Body|OG_half|OG_BodyShape.wm" "polyExtrudeFace16.mp";
connectAttr "polyExtrudeFace16.out" "polyExtrudeFace17.ip";
connectAttr "|Body|OG_half|OG_BodyShape.wm" "polyExtrudeFace17.mp";
connectAttr "polyExtrudeFace17.out" "polyExtrudeFace18.ip";
connectAttr "|Body|OG_half|OG_BodyShape.wm" "polyExtrudeFace18.mp";
connectAttr "polyExtrudeFace18.out" "polyExtrudeFace19.ip";
connectAttr "|Body|OG_half|OG_BodyShape.wm" "polyExtrudeFace19.mp";
connectAttr "polyTweak4.out" "polyExtrudeFace20.ip";
connectAttr "|Body|OG_half|OG_BodyShape.wm" "polyExtrudeFace20.mp";
connectAttr "polyExtrudeFace19.out" "polyTweak4.ip";
connectAttr "polyExtrudeFace20.out" "polyExtrudeFace21.ip";
connectAttr "|Body|OG_half|OG_BodyShape.wm" "polyExtrudeFace21.mp";
connectAttr "polyExtrudeFace21.out" "polyTweak5.ip";
connectAttr "polyTweak5.out" "deleteComponent5.ig";
connectAttr "deleteComponent5.og" "polySplit3.ip";
connectAttr "defaultRenderLayer.msg" ":defaultRenderingList1.r" -na;
connectAttr "|Body|OG_half|OG_BodyShape.iog" ":initialShadingGroup.dsm" -na;
connectAttr "|Body|OG_Body|OG_BodyShape.iog" ":initialShadingGroup.dsm" -na;
connectAttr "HeadShape.iog" ":initialShadingGroup.dsm" -na;
// End of New_Enemy.ma
