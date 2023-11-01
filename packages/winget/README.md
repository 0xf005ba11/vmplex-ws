# WINGET

We publish VMPlex to the winget package manager. This section of the source
maintains a record of manifests submitted to winget.

## Instructions

To submit a new release to winget, first you must build and publish a release
to the [VMPlex GitHub releases page](https://github.com/0xf005ba11/vmplex-ws/releases).
Once this is completed you can use the [wingetcreate](https://github.com/microsoft/winget-create)
tool to build a new manifest for that release and submit it to the
[winget packages repository](https://github.com/microsoft/winget-pkgs).

1. Move the root of the source tree.
2. Run the following `wingetcreate` command replacing the `[version]` with the
version being published.
    - `wingetcreate update VMPlex.VMPlex -u "https://github.com/0xf005ba11/vmplex-ws/releases/download/v[version]/VMPlex.exe|neutral" -v [version] -o .\packages\winget\`
3. Review the newly generated manifest in the source `.\packages\winget\manifests\v\VMPlex\VMPlex\[version]`.
4. Validate the newly generated manifest using `winget`.
    - `winget validate .\packages\winget\manifests\v\VMPlex\VMPlex\[version]`
5. Test that the generated manifest works as expected to update VMPlex.
    - `winget update -m .\packages\winget\manifests\v\VMPlex\VMPlex\[version]`
6. Submit the manifest to the winget packages repository using `wingetcreate`.
    - `wingetcreate submit -p "VMPlex.VMPlex version [version]" .\packages\winget\manifests\v\VMPlex\VMPlex\[version]`
7. A PR should have been created against the winget packages repository, once
accepted the build will be publicly available through winget.
8. Bump the revision (if appropriate) in `AssemblyInfo.cs` in this repository.
8. Submit a PR to this repository with the changes for recordkeeping.
