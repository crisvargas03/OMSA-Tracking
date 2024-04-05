import 'package:flutter/material.dart';
import 'package:omsa_tracking_app/core/app_export.dart';
import 'package:omsa_tracking_app/presentation/favourite_stops_screen/favourite_stops_screen.dart';
import 'package:omsa_tracking_app/presentation/maps_and_bus_time_screen/maps_and_bus_time_screen.dart';
import 'package:omsa_tracking_app/presentation/stop_buses_screen/stop_buses_screen.dart';
import 'package:omsa_tracking_app/presentation/turn_on_location_screen/turn_on_location_screen.dart';

class CustomBottomBar extends StatefulWidget {
  CustomBottomBar({this.onChanged});

  Function(BottomBarEnum)? onChanged;

  @override
  CustomBottomBarState createState() => CustomBottomBarState();
}
int selectedIndex = 1;
class CustomBottomBarState extends State<CustomBottomBar> {

  List<BottomMenuModel> bottomMenuList = [
    BottomMenuModel(
      icon: ImageConstant.imgMdiHeartOutline,
      activeIcon: ImageConstant.imgMdiHeartOutline,
      type: BottomBarEnum.Mdiheartoutline,
    ),
    BottomMenuModel(
      icon: ImageConstant.imgRiNavigationFill,
      activeIcon: ImageConstant.imgRiNavigationFill,
      type: BottomBarEnum.Rinavigationfill,
    ),
    BottomMenuModel(
      icon: ImageConstant.imgEosIconsRoute,
      activeIcon: ImageConstant.imgEosIconsRoute,
      type: BottomBarEnum.Eosiconsroute,
    )
  ];

  @override
  Widget build(BuildContext context) {
    return Container(
      height: 64.v,
      decoration: BoxDecoration(
        color: appTheme.whiteA700,
        boxShadow: [
          BoxShadow(
            color: appTheme.black900.withOpacity(0.2),
            spreadRadius: 2.h,
            blurRadius: 2.h,
            offset: Offset(
              -1,
              -1,
            ),
          ),
        ],
      ),
      child: BottomNavigationBar(
        backgroundColor: Colors.transparent,
        showSelectedLabels: false,
        showUnselectedLabels: false,
        selectedFontSize: 0,
        elevation: 0,
        currentIndex: selectedIndex,
        type: BottomNavigationBarType.fixed,
        items: List.generate(bottomMenuList.length, (index) {
          return BottomNavigationBarItem(
            icon: CustomImageView(
              imagePath: bottomMenuList[index].icon,
              height: 32.adaptSize,
              width: 32.adaptSize,
              color: appTheme.gray70001,
            ),
            activeIcon: Column(
              mainAxisSize: MainAxisSize.min,
              children: [
                CustomImageView(
                  imagePath: bottomMenuList[index].activeIcon,
                  height: 32.adaptSize,
                  width: 32.adaptSize,
                  color: appTheme.gray900,
                ),
                Opacity(
                  opacity: index == selectedIndex ? 1.0 : 0.0,
                  child: Container(
                    height: 4,
                    width: 32.adaptSize,
                    decoration: BoxDecoration(
                      boxShadow: [
                        BoxShadow(
                          color: Colors.black.withOpacity(0.2),
                          spreadRadius: 2,
                          blurRadius: 2,
                          offset: Offset(0, 1),
                        ),
                      ],
                    ),
                  ),
                ),
              ],
            ),
            label: '',
          );
        }),
        onTap: (index) {
          selectedIndex = index;
          widget.onChanged?.call(bottomMenuList[index].type);
          setState(() {
            // Aquí, dentro del onTap, puedes manejar la navegación.
            switch (bottomMenuList[index].type) {
              case BottomBarEnum.Mdiheartoutline:
                // Navegar a la pantalla correspondiente al primer ítem.
                // Por ejemplo:
                Navigator.push(context, MaterialPageRoute(builder: (context) => FavouriteStopsScreen()));
                selectedIndex = index;
                print('El Indice es:' + selectedIndex.toString());
                break;
              case BottomBarEnum.Rinavigationfill:
                // Navegar a la pantalla correspondiente al segundo ítem.
                // Por ejemplo:
                Navigator.push(context, MaterialPageRoute(builder: (context) => MapsAndBusTimeScreen()));
                selectedIndex = index;
                print('El Indice es:' + selectedIndex.toString());
                break;
              case BottomBarEnum.Eosiconsroute:
                // Navegar a la pantalla correspondiente al tercer ítem.
                // Por ejemplo:
                Navigator.push(context, MaterialPageRoute(builder: (context) => StopBusesScreen()));
                selectedIndex = index;
                print('El Indice es:' + selectedIndex.toString());
                break;
            }
          });
        },
      ),
    );
  }
}

enum BottomBarEnum {
  Mdiheartoutline,
  Rinavigationfill,
  Eosiconsroute,
}

class BottomMenuModel {
  BottomMenuModel({
    required this.icon,
    required this.activeIcon,
    required this.type,
  });

  String icon;

  String activeIcon;

  BottomBarEnum type;
}

class DefaultWidget extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Container(
      color: Color(0xffffffff),
      padding: EdgeInsets.all(10),
      child: Center(
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          mainAxisAlignment: MainAxisAlignment.center,
          children: [
            Text(
              'Please replace the respective Widget here',
              style: TextStyle(
                fontSize: 18,
              ),
            ),
          ],
        ),
      ),
    );
  }
}
