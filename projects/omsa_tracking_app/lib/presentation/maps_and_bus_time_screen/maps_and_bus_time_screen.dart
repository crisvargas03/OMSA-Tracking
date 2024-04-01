import 'package:google_maps_flutter/google_maps_flutter.dart';
import 'dart:async';
import 'package:omsa_tracking_app/widgets/custom_bottom_bar.dart';
import 'package:flutter/material.dart';
import 'package:omsa_tracking_app/core/app_export.dart';

class MapsAndBusTimeScreen extends StatelessWidget {
  MapsAndBusTimeScreen({Key? key})
      : super(
          key: key,
        );

  Completer<GoogleMapController> googleMapController = Completer();

  GlobalKey<NavigatorState> navigatorKey = GlobalKey();

  @override
  Widget build(BuildContext context) {
    return SafeArea(
      child: Scaffold(
        body: SizedBox(
          height: 867.v,
          width: double.maxFinite,
          child: Stack(
            alignment: Alignment.bottomCenter,
            children: [
              _buildMap(context),
              Align(
                alignment: Alignment.bottomCenter,
                child: Container(
                  padding: EdgeInsets.symmetric(
                    horizontal: 15.h,
                    vertical: 22.v,
                  ),
                  decoration: AppDecoration.outlineBlack.copyWith(
                    borderRadius: BorderRadiusStyle.customBorderTL32,
                  ),
                  child: Column(
                    mainAxisSize: MainAxisSize.min,
                    crossAxisAlignment: CrossAxisAlignment.start,
                    children: [
                      SizedBox(
                        width: 218.h,
                        child: Divider(
                          indent: 155.h,
                        ),
                      ),
                      SizedBox(height: 12.v),
                      Padding(
                        padding: EdgeInsets.only(left: 20.h),
                        child: Text(
                          "Autobuses Cercanos",
                          style: CustomTextStyles.headlineSmallGray900,
                        ),
                      ),
                      SizedBox(height: 11.v),
                      _buildStopsContainer(context),
                      SizedBox(height: 53.v),
                    ],
                  ),
                ),
              ),
            ],
          ),
        ),
        bottomNavigationBar: _buildBottomBar(context),
      ),
    );
  }

  /// Section Widget
  Widget _buildMap(BuildContext context) {
    return Align(
      alignment: Alignment.topCenter,
      child: SizedBox(
        height: 4.v,
        width: double.maxFinite,
        child: Stack(
          alignment: Alignment.topCenter,
          children: [
            CustomImageView(
              imagePath: ImageConstant.imgImage1,
              width: 430.h,
              alignment: Alignment.center,
            ),
            SizedBox(
              height: 400.v,
              width: 500.h,
              child: GoogleMap(
                //TODO: Add your Google Maps API key in AndroidManifest.xml and pod file
                mapType: MapType.normal,
                initialCameraPosition: CameraPosition(
                  target: LatLng(
                    37.43296265331129,
                    -122.08832357078792,
                  ),
                  zoom: 14.4746,
                ),
                onMapCreated: (GoogleMapController controller) {
                  googleMapController.complete(controller);
                },
                zoomControlsEnabled: false,
                zoomGesturesEnabled: false,
                myLocationButtonEnabled: false,
                myLocationEnabled: false,
              ),
            ),
          ],
        ),
      ),
    );
  }

  /// Section Widget
  Widget _buildStopsContainer(BuildContext context) {
    return Container(
      margin: EdgeInsets.only(right: 6.h),
      padding: EdgeInsets.symmetric(
        horizontal: 20.h,
        vertical: 13.v,
      ),
      decoration: AppDecoration.fillGray.copyWith(
        borderRadius: BorderRadiusStyle.roundedBorder16,
      ),
      child: Column(
        mainAxisSize: MainAxisSize.min,
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          Padding(
            padding: EdgeInsets.only(right: 16.h),
            child: Row(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                Expanded(
                  child: Container(
                    padding: EdgeInsets.symmetric(
                      horizontal: 9.h,
                      vertical: 7.v,
                    ),
                    decoration: AppDecoration.fillAmber.copyWith(
                      borderRadius: BorderRadiusStyle.roundedBorder8,
                    ),
                    child: Row(
                      crossAxisAlignment: CrossAxisAlignment.start,
                      children: [
                        Text(
                          "43B",
                          style: theme.textTheme.titleSmall,
                        ),
                        Padding(
                          padding: EdgeInsets.only(
                            left: 10.h,
                            bottom: 3.v,
                          ),
                          child: Text(
                            "Av. 27 de Febrero Proximo Av. Maximo Gomez",
                            style: CustomTextStyles.bodySmall10,
                          ),
                        ),
                      ],
                    ),
                  ),
                ),
                CustomImageView(
                  imagePath: ImageConstant.imgArrowUp,
                  width: 18.h,
                  margin: EdgeInsets.only(
                    left: 36.h,
                    top: 6.v,
                    bottom: 7.v,
                  ),
                ),
              ],
            ),
          ),
          SizedBox(height: 12.v),
          Container(
            padding: EdgeInsets.symmetric(
              horizontal: 9.h,
              vertical: 13.v,
            ),
            decoration: AppDecoration.outlineBlack900.copyWith(
              borderRadius: BorderRadiusStyle.roundedBorder8,
            ),
            child: Row(
              mainAxisAlignment: MainAxisAlignment.end,
              children: [
                CustomImageView(
                  imagePath: ImageConstant.imgCar,
                  width: 14.h,
                ),
                Container(
                  height: 15.v,
                  width: 289.h,
                  margin: EdgeInsets.only(left: 25.h),
                  child: Stack(
                    alignment: Alignment.centerRight,
                    children: [
                      Align(
                        alignment: Alignment.center,
                        child: SizedBox(
                          width: 289.h,
                          child: Row(
                            mainAxisAlignment: MainAxisAlignment.spaceBetween,
                            children: [
                              Text(
                                "Bus B340M",
                                style: CustomTextStyles.bodySmallLight,
                              ),
                              Text(
                                "Vencida",
                                style: CustomTextStyles.labelLargeRed400,
                              ),
                            ],
                          ),
                        ),
                      ),
                      Align(
                        alignment: Alignment.centerRight,
                        child: Padding(
                          padding: EdgeInsets.only(right: 59.h),
                          child: Row(
                            mainAxisAlignment: MainAxisAlignment.center,
                            mainAxisSize: MainAxisSize.min,
                            children: [
                              CustomImageView(
                                imagePath: ImageConstant.imgUpload,
                                height: 14.v,
                                margin: EdgeInsets.only(bottom: 1.v),
                              ),
                              Padding(
                                padding: EdgeInsets.only(left: 6.h),
                                child: Text(
                                  "84 / 220",
                                  style: theme.textTheme.bodySmall,
                                ),
                              ),
                            ],
                          ),
                        ),
                      ),
                    ],
                  ),
                ),
              ],
            ),
          ),
          SizedBox(height: 8.v),
          Container(
            padding: EdgeInsets.symmetric(
              horizontal: 11.h,
              vertical: 13.v,
            ),
            decoration: AppDecoration.outlineBlack900.copyWith(
              borderRadius: BorderRadiusStyle.roundedBorder8,
            ),
            child: Row(
              mainAxisAlignment: MainAxisAlignment.end,
              children: [
                CustomImageView(
                  imagePath: ImageConstant.imgCar,
                  width: 14.h,
                ),
                Container(
                  height: 15.v,
                  width: 287.h,
                  margin: EdgeInsets.only(left: 24.h),
                  child: Stack(
                    alignment: Alignment.centerRight,
                    children: [
                      Align(
                        alignment: Alignment.center,
                        child: SizedBox(
                          width: 287.h,
                          child: Row(
                            mainAxisAlignment: MainAxisAlignment.spaceBetween,
                            children: [
                              SizedBox(
                                height: 15.v,
                                width: 59.h,
                                child: Stack(
                                  alignment: Alignment.center,
                                  children: [
                                    Align(
                                      alignment: Alignment.center,
                                      child: Text(
                                        "Bus B347G",
                                        style: CustomTextStyles.bodySmallLight,
                                      ),
                                    ),
                                    Align(
                                      alignment: Alignment.center,
                                      child: Text(
                                        "Bus B347G",
                                        style: CustomTextStyles.bodySmallLight,
                                      ),
                                    ),
                                  ],
                                ),
                              ),
                              SizedBox(
                                height: 15.v,
                                width: 34.h,
                                child: Stack(
                                  alignment: Alignment.center,
                                  children: [
                                    Align(
                                      alignment: Alignment.center,
                                      child: Text(
                                        "6 min.",
                                        style: theme.textTheme.labelLarge,
                                      ),
                                    ),
                                    Align(
                                      alignment: Alignment.center,
                                      child: Text(
                                        "6 min.",
                                        style: theme.textTheme.labelLarge,
                                      ),
                                    ),
                                  ],
                                ),
                              ),
                            ],
                          ),
                        ),
                      ),
                      Align(
                        alignment: Alignment.centerRight,
                        child: Padding(
                          padding: EdgeInsets.only(right: 57.h),
                          child: Row(
                            mainAxisAlignment: MainAxisAlignment.center,
                            mainAxisSize: MainAxisSize.min,
                            children: [
                              Container(
                                height: 14.v,
                                width: 15.h,
                                margin: EdgeInsets.only(bottom: 1.v),
                                child: Stack(
                                  alignment: Alignment.center,
                                  children: [
                                    CustomImageView(
                                      imagePath: ImageConstant.imgUpload,
                                      height: 14.v,
                                      alignment: Alignment.center,
                                    ),
                                    CustomImageView(
                                      imagePath: ImageConstant.imgUpload,
                                      height: 14.v,
                                      alignment: Alignment.center,
                                    ),
                                  ],
                                ),
                              ),
                              Container(
                                height: 15.v,
                                width: 45.h,
                                margin: EdgeInsets.only(left: 6.h),
                                child: Stack(
                                  alignment: Alignment.center,
                                  children: [
                                    Align(
                                      alignment: Alignment.center,
                                      child: Text(
                                        "68 / 140",
                                        style: theme.textTheme.bodySmall,
                                      ),
                                    ),
                                    Align(
                                      alignment: Alignment.center,
                                      child: Text(
                                        "68 / 140",
                                        style: theme.textTheme.bodySmall,
                                      ),
                                    ),
                                  ],
                                ),
                              ),
                            ],
                          ),
                        ),
                      ),
                    ],
                  ),
                ),
              ],
            ),
          ),
          SizedBox(height: 8.v),
          Container(
            padding: EdgeInsets.symmetric(
              horizontal: 7.h,
              vertical: 13.v,
            ),
            decoration: AppDecoration.outlineBlack900.copyWith(
              borderRadius: BorderRadiusStyle.roundedBorder8,
            ),
            child: Row(
              mainAxisAlignment: MainAxisAlignment.end,
              children: [
                Expanded(
                  child: Row(
                    mainAxisAlignment: MainAxisAlignment.end,
                    children: [
                      CustomImageView(
                        imagePath: ImageConstant.imgCar,
                        width: 14.h,
                      ),
                      Padding(
                        padding: EdgeInsets.only(
                          left: 24.h,
                          top: 2.v,
                        ),
                        child: Text(
                          "Bus C240M",
                          style: CustomTextStyles.bodySmallLight,
                        ),
                      ),
                      Spacer(),
                      CustomImageView(
                        imagePath: ImageConstant.imgUpload,
                        height: 14.v,
                        margin: EdgeInsets.only(bottom: 2.v),
                      ),
                      Padding(
                        padding: EdgeInsets.only(
                          left: 6.h,
                          top: 2.v,
                        ),
                        child: Text(
                          "140 / 140",
                          style: theme.textTheme.bodySmall,
                        ),
                      ),
                    ],
                  ),
                ),
                Padding(
                  padding: EdgeInsets.only(
                    left: 13.h,
                    bottom: 2.v,
                  ),
                  child: Text(
                    "18 min.",
                    style: theme.textTheme.labelLarge,
                  ),
                ),
              ],
            ),
          ),
          SizedBox(height: 8.v),
          _buildStop5(
            context,
            distance: "Bus B342M",
            twoHundredTenThousandTwoHundre: "100 / 220",
            time: "40 min.",
          ),
          SizedBox(height: 9.v),
          _buildStop5(
            context,
            distance: "Bus B353M",
            twoHundredTenThousandTwoHundre: "210 / 220",
            time: "49 min.",
          ),
          SizedBox(height: 9.v),
        ],
      ),
    );
  }

  /// Section Widget
  Widget _buildBottomBar(BuildContext context) {
    return CustomBottomBar(
      onChanged: (BottomBarEnum type) {},
    );
  }

  /// Common widget
  Widget _buildStop5(
    BuildContext context, {
    required String distance,
    required String twoHundredTenThousandTwoHundre,
    required String time,
  }) {
    return Container(
      padding: EdgeInsets.symmetric(
        horizontal: 7.h,
        vertical: 13.v,
      ),
      decoration: AppDecoration.outlineBlack900.copyWith(
        borderRadius: BorderRadiusStyle.roundedBorder8,
      ),
      child: Row(
        mainAxisAlignment: MainAxisAlignment.end,
        children: [
          CustomImageView(
            imagePath: ImageConstant.imgCar,
            width: 14.h,
            margin: EdgeInsets.only(left: 10.h),
          ),
          Padding(
            padding: EdgeInsets.only(
              left: 24.h,
              top: 2.v,
            ),
            child: Text(
              distance,
              style: CustomTextStyles.bodySmallLight.copyWith(
                color: appTheme.black900,
              ),
            ),
          ),
          Spacer(),
          CustomImageView(
            imagePath: ImageConstant.imgUpload,
            height: 14.v,
            margin: EdgeInsets.only(bottom: 2.v),
          ),
          Padding(
            padding: EdgeInsets.only(
              left: 6.h,
              top: 2.v,
            ),
            child: Text(
              twoHundredTenThousandTwoHundre,
              style: theme.textTheme.bodySmall!.copyWith(
                color: appTheme.black900,
              ),
            ),
          ),
          Padding(
            padding: EdgeInsets.only(
              left: 13.h,
              top: 2.v,
            ),
            child: Text(
              time,
              style: theme.textTheme.labelLarge!.copyWith(
                color: appTheme.black900,
              ),
            ),
          ),
        ],
      ),
    );
  }
}
