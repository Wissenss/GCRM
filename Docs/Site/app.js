const GITHUB_REPO = "Wissenss/GCRM";
const RELEASES_API_URL = `https://api.github.com/repos/${GITHUB_REPO}/releases`;

const statusEl = document.getElementById("releases-status");
const listEl = document.getElementById("releases-list");
const downloadLatestBtn = document.getElementById("download-latest-btn");

function formatSize(bytes) {
  const mb = bytes / (1024 * 1024);
  return `${mb.toFixed(1)} MB`;
}

function formatDate(isoDate) {
  return new Date(isoDate).toLocaleDateString(undefined, {
    year: "numeric",
    month: "short",
    day: "numeric",
  });
}

function findAsset(assets, arch) {
  return assets.find((asset) => asset.name.toLowerCase().includes(arch));
}

function renderAssetCell(asset) {
  if (!asset) return '<span class="asset-none">&mdash;</span>';
  return `
    <a class="asset-link" href="${asset.browser_download_url}" download>
      Download
      <span class="asset-size">${formatSize(asset.size)}</span>
    </a>`;
}

function updateLatestDownloadButton(latestRelease) {
  const x64 = latestRelease && findAsset(latestRelease.assets, "x64");
  if (!x64) {
    downloadLatestBtn.hidden = true;
    return;
  }
  downloadLatestBtn.href = x64.browser_download_url;
  downloadLatestBtn.hidden = false;
}

function renderReleases(releases) {
  if (releases.length === 0) {
    statusEl.textContent = "No releases published yet.";
    return;
  }

  updateLatestDownloadButton(releases[0]);
  statusEl.textContent = "";
  listEl.innerHTML = releases
    .map((release, index) => {
      const badges = [];
      if (index === 0) badges.push('<span class="badge latest">Latest</span>');
      if (release.prerelease) badges.push('<span class="badge prerelease">Pre-release</span>');

      const x64 = findAsset(release.assets, "x64");
      const x86 = findAsset(release.assets, "x86");

      return `
        <tr class="${index === 0 ? "latest-row" : ""}">
          <td>
            <span class="release-version">${release.tag_name}</span>
            ${badges.join("")}
          </td>
          <td class="release-date">${formatDate(release.published_at)}</td>
          <td>${renderAssetCell(x64)}</td>
          <td>${renderAssetCell(x86)}</td>
        </tr>`;
    })
    .join("");
}

async function loadReleases() {
  statusEl.textContent = "Loading releases...";
  try {
    const response = await fetch(RELEASES_API_URL, {
      headers: { Accept: "application/vnd.github+json" },
    });

    if (!response.ok) {
      throw new Error(`GitHub API responded with ${response.status}`);
    }

    const releases = await response.json();
    renderReleases(releases);
  } catch (error) {
    statusEl.textContent =
      "Could not load releases from GitHub. You can view them directly on the ";
    const link = document.createElement("a");
    link.href = `https://github.com/${GITHUB_REPO}/releases`;
    link.target = "_blank";
    link.rel = "noopener";
    link.textContent = "GCRM releases page";
    statusEl.appendChild(link);
    statusEl.classList.add("error");
    console.error(error);
  }
}

loadReleases();
