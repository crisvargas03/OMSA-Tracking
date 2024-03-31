import 'package:permission_handler/permission_handler.dart';
import 'package:omsa_tracking_app/widgets/custom_elevated_button.dart';
import 'package:flutter/material.dart';
import 'package:omsa_tracking_app/core/app_export.dart';

class TurnOnLocationScreen extends StatelessWidget {
  const TurnOnLocationScreen({Key? key})
      : super(
          key: key,
        );

  @override
  Widget build(BuildContext context) {
    return SafeArea(
      child: Scaffold(
        body: Container(
          width: double.maxFinite,
          padding: EdgeInsets.symmetric(horizontal: 11.h),
          child: Column(
            mainAxisAlignment: MainAxisAlignment.center,
            children: [
              SizedBox(height: 56.v),
              CustomImageView(
                imagePath: ImageConstant.imgMainImage,
                height: 363.v,
              ),
              SizedBox(height: 92.v),
              Container(
                width: 351.h,
                margin: EdgeInsets.only(
                  left: 27.h,
                  right: 28.h,
                ),
                child: Text(
                  "Activar la ubicación para encontrar paradas de autobuses cercanos",
                  maxLines: 2,
                  overflow: TextOverflow.ellipsis,
                  textAlign: TextAlign.center,
                  style: CustomTextStyles.bodyLarge17,
                ),
              ),
              SizedBox(height: 33.v),
              CustomElevatedButton(
                onPressed: () async {
                  PermissionStatus permission = await Permission.locationWhenInUse.request();
                  if (permission.isGranted) {
                    print("Location permission granted");
                    Navigator.pushNamed(
                      context,
                      AppRoutes.mapsAndBusTimeScreen,
                    );
                  } else {
                    print("Location permission denied");
                  }
                },
                width: 199.h,
                text: "Activar Ubicación",
              ),
              SizedBox(height: 19.v),
              Text(
                "Buscaré manualmente",
                style: CustomTextStyles.bodyLargeLight.copyWith(
                  decoration: TextDecoration.underline,
                ),
              ),
              SizedBox(height: 53.v),
              CustomImageView(
                imagePath: ImageConstant.imgLogoOmsa,
                height: 70.v,
              ),
            ],
          ),
        ),
      ),
    );
  }
}
